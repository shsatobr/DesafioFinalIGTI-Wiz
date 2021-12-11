using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Services.Auth.Jwt
{
    public class JwtConfiguracoes
    {
        public string Emissor { get; set; }
        public string Audiencia { get; set; }
        public string Segredo { get; set; }
        public int ValidadeMinutos { get; set; }
    }
}
