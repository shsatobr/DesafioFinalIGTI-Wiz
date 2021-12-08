﻿using DesafioFinalIGTIWiz.Context;
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
    public class AutoresController :ControllerBase
    {
        private readonly LivrariaDbContext _livrariaDbContext;
        public AutoresController(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAutor(AutorInput dadosEntrada)
        {
            var autor = new Autor()
            {
                Nome = dadosEntrada.Nome,
                Sobrenome = dadosEntrada.Sobrenome
            };
            await _livrariaDbContext.Autores.AddAsync(autor);
            await _livrariaDbContext.SaveChangesAsync();
            return Ok("Cadastro de autor feito com sucesso");
        }


    }
}
