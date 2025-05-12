using Microsoft.IdentityModel.Tokens;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Papeleria.WebApi
{
    public class ManejadorJWT
    {
        public static string GenerarToken(UsuarioDto usuarioDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //clave secreta, podriamos incluirlo en archivo appsettings
            var clave = Encoding.ASCII.GetBytes("UruguayCAmpeondeAM3ricaDOSMILVEInti4!,ComoENel2milOncE");

            //Se incluye un claim para el rol
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuarioDto.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
