using DesafioFinalIGTIWiz.Context;
using DesafioFinalIGTIWiz.InputModel;
using DesafioFinalIGTIWiz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly LivrariaDbContext _livrariaDbContext;

        public UsuariosController(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(UsuarioInput dadosEntrada)
        {
            var usuario = new Usuario()
            {
                Nome = dadosEntrada.Nome,
                Email = dadosEntrada.Email,
                Senha = dadosEntrada.Senha,
                RoleId = dadosEntrada.RoleId,
                CriadoEm = DateTime.Now
            };
            await _livrariaDbContext.Usuarios.AddAsync(usuario);
            await _livrariaDbContext.SaveChangesAsync();
            return Ok("Cadastro de usuário feito com sucesso");
        }
        
    }
}
