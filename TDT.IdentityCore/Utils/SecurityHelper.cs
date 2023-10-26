using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.Models;

namespace TDT.IdentityCore.Utils
{
    public interface ISecurityHelper
    {
        public string GenerateJWT(User userInfo, bool isExpr = true, double expr = 120);
        public IEnumerable<Claim> ValidateToken(string token);
        public string GeneratePasswordResetToken(string email);
    }
    public class SecurityHelper : ISecurityHelper
    {
        private static readonly int SALT_SIZE = 32;
        private static readonly int ITERATIONS = 3000;
        private readonly IConfiguration _cfg;
        public SecurityHelper(IConfiguration cfg)
        {
            _cfg = cfg;
        }

        public static string HashPassword(string password)
        {            
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SALT_SIZE, ITERATIONS))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(SALT_SIZE * 2);
            }
            byte[] dst = new byte[SALT_SIZE + 1 + SALT_SIZE * 2];
            Buffer.BlockCopy(salt, 0, dst, 1, SALT_SIZE);
            Buffer.BlockCopy(buffer2, 0, dst, SALT_SIZE + 1, SALT_SIZE * 2);
            return Convert.ToBase64String(dst);
        }
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != SALT_SIZE + 1 + SALT_SIZE * 2) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[SALT_SIZE];
            Buffer.BlockCopy(src, 1, dst, 0, SALT_SIZE);
            byte[] buffer3 = new byte[SALT_SIZE * 2];
            Buffer.BlockCopy(src, SALT_SIZE + 1, buffer3, 0, SALT_SIZE * 2);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, ITERATIONS))
            {
                buffer4 = bytes.GetBytes(SALT_SIZE * 2);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
        /// <summary>
        /// Generate JWT for user authentication
        /// </summary>
        /// <param name="_cfg">Global config</param>
        /// <param name="userInfo">User model</param>
        /// <param name="isExpr">Is expire?</param>
        /// <param name="expr">Expired time(Minutes)</param>
        /// <returns>JWT</returns>
        public string GenerateJWT(User userInfo, bool isExpr = true, double expr = 120)
        {
            var listRoleGroup = "";
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim(ClaimTypes.Role, listRoleGroup)
            };
            var token = new JwtSecurityToken(
                _cfg["Jwt:Issuer"],
                _cfg["Jwt:Audience"],
                claims,
                expires: isExpr ? DateTime.UtcNow.AddMinutes(expr) : DateTime.UtcNow.AddYears(10),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GeneratePasswordResetToken(string email)
        {
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                _cfg["Jwt:Issuer"],
                _cfg["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public IEnumerable<Claim> ValidateToken(string token)
        {
            if (token == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var secirityKey = Encoding.ASCII.GetBytes(Convert.ToString(_cfg["Jwt:Key"]));
            try
            {       
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _cfg["Jwt:Issuer"],
                    ValidAudience = _cfg["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]))
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //var jti = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "jti").Value;
                //var userName = jwtToken.Claims.FirstOrDefault(sub => sub.Type == "sub").Value;

                return jwtToken.Claims;
            }
            catch (Exception ex)
            {               
                return null;
            }
        }
    }
}
