using DesafioFinalIGTIWiz.Context;
using DesafioFinalIGTIWiz.InputModel;
using DesafioFinalIGTIWiz.Models;
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
            var autor = await _livrariaDbContext.Autores.Where(x => x.Id == dadosEntrada.AutorId).FirstOrDefaultAsync(); // Pesquisa pelo autor
            if (autor != null)
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
            return NotFound("Autor não cadastrado");
        }

        [HttpGet("PesquisaPorDescricao")]
        public async Task<IActionResult> PesquisarLivro(string nomeLivro)
        {
            var livro = await _livrariaDbContext.Livros.Where(x => x.Descricao.Contains(nomeLivro)).ToListAsync();
            if (livro != null)
                return Ok(livro);
            return NotFound("Livro não encontrado");
        }

        [HttpGet("Pesquisa-Por-ISBN")]
        public async Task<IActionResult> PesquisaPorISBN(int ISBN)
        {
            var livro = await _livrariaDbContext.Livros.Where(x => x.ISBN == ISBN).ToListAsync();
            if (livro != null)
                return Ok(livro);
            return NotFound("Livro não encontrado");
        }

        [HttpGet("PesquisaPorAnoLancamento")]
        public async Task<IActionResult> PesquisaPorAnoLancamento(int anoLancamento)
        {
            var livro = await _livrariaDbContext.Livros.Where(x => x.AnoLancamento == anoLancamento).ToListAsync();
            if (livro != null)
                return Ok(livro);
            return NotFound("Livro não encontrado");
        }

        [HttpPut]
        public async Task<IActionResult> AlteraLivros(LivroUpdate dadosEntrada)
        {
            var livro = await _livrariaDbContext.Livros.Where(x => x.Id == dadosEntrada.LivroId).FirstOrDefaultAsync();
            if (livro != null)
            {
                livro.Descricao = dadosEntrada.Descricao;
                livro.AnoLancamento = dadosEntrada.AnoLancamento;
                _livrariaDbContext.Livros.Update(livro);
                await _livrariaDbContext.SaveChangesAsync();
                return Ok("Regsitro alterado");
            }
            return NotFound("Livro não encontrado");
        }

        [HttpDelete]
        public async Task<IActionResult> ApagarLivro(int id)
        {
            var livro = await _livrariaDbContext.Livros.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (livro != null)
            {
                _livrariaDbContext.Livros.Remove(livro);
                await _livrariaDbContext.SaveChangesAsync();
                return Ok("Registro excluido");
            }
            return NotFound("Livro não encontrado");
        }
    }
}
