using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.InputModel
{
    public class UsuarioInput
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int RoleId { get; set; }
        public DateTime CriadoEm { get; set; }
     }
}
