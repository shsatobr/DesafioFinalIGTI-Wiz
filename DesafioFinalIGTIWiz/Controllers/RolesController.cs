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
    public class RolesController: ControllerBase
    {
        private readonly LivrariaDbContext _livrariaDbContext;

        public RolesController(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarRole(RoleInput dadosEntrada)
        {
            var role = new Role()
            {
                Nome = dadosEntrada.Nome
            };
            await _livrariaDbContext.Roles.AddAsync(role);
            await _livrariaDbContext.SaveChangesAsync();
            return Ok("Cargo incluido com sucesso");
        }
    }
}
