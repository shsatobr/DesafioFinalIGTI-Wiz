using DesafioFinalIGTIWiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Dados.Repositorio.Interfaces
{
    public  interface IUsuarioRepository
    {
        Task<int> Adicionar(Usuario usuario);
        Task<IEnumerable<Usuario>> RecuperarTodos();
        Task<bool> VerificarUsuario(string email, string senha);
        Task<Usuario> RecuperarPorCredenciais(string email, string senha);
    }
}
