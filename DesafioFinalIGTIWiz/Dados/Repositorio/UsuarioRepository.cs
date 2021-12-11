using DesafioFinalIGTIWiz.Context;
using DesafioFinalIGTIWiz.Dados.Repositorio.Interfaces;
using DesafioFinalIGTIWiz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Dados.Repositorio
{

    public class UsuarioRepository : IUsuarioRepository
    {
        #region Campos
        private readonly LivrariaDbContext _livrariaDbContext;
        #endregion

        #region Construtor
        public UsuarioRepository(LivrariaDbContext livrariaDbContext)
        {
            _livrariaDbContext = livrariaDbContext;
        }
        #endregion
        #region Métodos
        public async Task<int> Adicionar(Usuario usuario)
        {
            _livrariaDbContext.Usuarios.Add(usuario);
            return await _livrariaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> RecuperarTodos()
        {
            return await _livrariaDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> RecuperarPorCredenciais(string email, string senha)
        {
            return await _livrariaDbContext.Usuarios.SingleOrDefaultAsync(usuario => usuario.Email == email && usuario.Senha == senha);
        }

        public async Task<bool> VerificarUsuario(string email, string senha)
        {
            var usuario = await _livrariaDbContext.Usuarios.SingleOrDefaultAsync(usuario=> usuario.Email == email && usuario.Senha == senha);
            return usuario == null;
        }
        #endregion
    }
}
