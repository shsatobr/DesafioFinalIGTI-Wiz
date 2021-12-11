using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Services.Auth.Jwt
{
    public class JwtCredenciais
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
