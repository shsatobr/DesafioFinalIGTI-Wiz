using DesafioFinalIGTIWiz.Context;
using DesafioFinalIGTIWiz.Dados.Repositorio;
using DesafioFinalIGTIWiz.Dados.Repositorio.Interfaces;
using DesafioFinalIGTIWiz.InputModel;
using DesafioFinalIGTIWiz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (!usuario.EhValido())
                {
                    return BadRequest();
                }
                var affectedRows = await _usuarioRepository.Adicionar(usuario);
                if (affectedRows == 1)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                { 
                    CodigoStatus = StatusCodes.Status500InternalServerError,
                    Mensagem = e.Message
                });
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioRepository.RecuperarTodos();
            return Ok(usuarios);
        }
     
        
    }
}
