using DesafioFinalIGTIWiz.Configuracao;
using DesafioFinalIGTIWiz.Context;
using DesafioFinalIGTIWiz.Dados.Repositorio;
using DesafioFinalIGTIWiz.Dados.Repositorio.Interfaces;
using DesafioFinalIGTIWiz.Services.Auth.Jwt;
using DesafioFinalIGTIWiz.Services.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Contextos
            // Contextos
            services.AddDbContext<LivrariaDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Livraria", Version = "v1" });
            });

            #region JWT
            // Configurações JWT
            var sessao = Configuration.GetSection("JwtConfiguracoes");
            services.Configure<JwtConfiguracoes>(sessao);

            //Serviços / Gerenciamento JWT
            services.AddScoped<IJwtAuthGerenciador, JwtAuthGerenciador>();

            // Autenticacao JWT
            services.AddConfiguracaoAuth(Configuration);

            // Repositorios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            // services.AddScope<IContatoRepositorio, ContatoRepositorio();

            #endregion

            // Controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Livraria v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
