using Microsoft.IdentityModel.Tokens;
using Projeto.CrossCutting.Security.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto.CrossCutting.Security.Services
{
    public class TokenService
    {
        private readonly AppSettings appSettings;

        public TokenService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //conteudo do token
            var tokenDescription = new SecurityTokenDescriptor
            {
                //definicoes do usuario
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),

                //tempo de expiracao do token
                Expires = DateTime.Now.AddDays(1),

                //criptografia do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
