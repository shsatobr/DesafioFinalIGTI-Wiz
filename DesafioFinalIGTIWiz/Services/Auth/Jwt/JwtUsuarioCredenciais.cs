using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Services.Auth.Jwt
{
    public class JwtUsuarioCredenciais
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Senha { get; set; }
    }
}
