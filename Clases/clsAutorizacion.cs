using Microsoft.IdentityModel.Tokens;
using NATILLERA.Entidades;
using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NATILLERA.Clases
{
    public class clsAutorizacion
    {
        private NATILLERAEntities _db = new NATILLERAEntities();
        private readonly string _llave = "estaSeriaLaClaveSecretaParaMiApi";
        
        public bool ValidacionUsuario(AccesoUsuario acceso)
        {
            _ = acceso == null ? throw new ArgumentNullException(nameof(acceso)) : acceso;
            _ = acceso.Usuario == null ? throw new ArgumentNullException(nameof(acceso)) : acceso;
            _ = acceso.Contraseña == null ? throw new ArgumentNullException(nameof(acceso)) : acceso;

            string adminUser = _db.tblUsuarios.Where(admin => admin.varNombreUsuario == acceso.Usuario && admin.varPasswordHash == acceso.Contraseña).
                                    Select(admin => admin.varPasswordHash).FirstOrDefault();

            return string.IsNullOrEmpty(adminUser) ? false : true;

        }

        public string GenerateToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_llave));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "NATILLERA",
                audience: "NATILLERA",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_llave));
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = "NATILLERA",
                    ValidAudience = "NATILLERA"
                }, out SecurityToken validatedToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}