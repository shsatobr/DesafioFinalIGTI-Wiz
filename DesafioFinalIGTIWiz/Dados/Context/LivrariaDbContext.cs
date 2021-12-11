using DesafioFinalIGTIWiz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Context
{
    public class LivrariaDbContext : DbContext
    {
        #region DBSets - Acesso as tabelas
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion


        #region Construtor - Para acesso do BD
        public LivrariaDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region Definindo mapeamento das tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivrariaDbContext).Assembly);     // Indica que onde pegar os mapeamentos
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}

