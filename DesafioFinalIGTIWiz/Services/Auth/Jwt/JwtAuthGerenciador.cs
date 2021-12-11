using DesafioFinalIGTIWiz.Services.Auth.Jwt.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Services.Auth.Jwt
{
    public class JwtAuthGerenciador: IJwtAuthGerenciador
    {
        #region Campos
        private readonly JwtConfiguracoes jwtConfiguracoes;
        #endregion

        #region Construtor
        public JwtAuthGerenciador(IOptions<JwtConfiguracoes> jwtConfiguracoes)
        {
            this.jwtConfiguracoes = jwtConfiguracoes.Value;
        }
        #endregion

        public JwtAuthModelo GerarToken(JwtCredenciais credenciais)
        {
            var declaracoes = new List<Claim>
            {
                new Claim(ClaimTypes.Email, credenciais.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, credenciais.Role)
            };

            var chave = Encoding.ASCII.GetBytes(jwtConfiguracoes.Segredo);

            var jwtToken = new JwtSecurityToken(
                jwtConfiguracoes.Emissor,
                jwtConfiguracoes.Audiencia,
                declaracoes,
                expires: DateTime.Now.AddMinutes(jwtConfiguracoes.ValidadeMinutos),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new JwtAuthModelo
            {
                TokenAcesso = accessToken,
                Tokentype = "bearer",
                ExpiraEm = jwtConfiguracoes.ValidadeMinutos * 60
            };
        }
    }
}
