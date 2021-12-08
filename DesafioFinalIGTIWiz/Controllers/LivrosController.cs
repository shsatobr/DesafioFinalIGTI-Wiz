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
    public class LivrosController : ControllerBase
    {
        private readonly LivrariaDbContext _livrariaDbContext;
       
        public LivrosController(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarLivro(LivroInput dadosEntrada)
        {
            var livro = new Livro()
            {
                Descricao = dadosEntrada.Descricao,
                ISBN = dadosEntrada.ISBN,
                AnoLancamento = dadosEntrada.AnoLancamento,
                AutorId = dadosEntrada.AutorId,
                CriadoEm = DateTime.Now
            };

            await _livrariaDbContext.Livros.AddAsync(livro);
            await _livrariaDbContext.SaveChangesAsync();
            //return Ok("Cadastro de livro feito com sucesso");
            return Ok(
                new
                {
                    descricao = livro.Descricao,
                    isbn = livro.ISBN
                }
            );
        }
    }
}
