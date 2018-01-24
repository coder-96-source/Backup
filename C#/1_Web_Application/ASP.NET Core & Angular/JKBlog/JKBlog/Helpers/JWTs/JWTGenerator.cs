using JKBlog.Models.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JKBlog.Helpers.JWTs
{
    public class JWTGenerator
    {
        private readonly IConfiguration _configuration;

        public JWTGenerator(IConfiguration configurations)
        {
            this._configuration = configurations;
        }

        public string GetToken(User user)
        {
            return BuildToken(user);
        }

        private string BuildToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: this._configuration["Jwt:Issuer"],
              audience: this._configuration["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(Convert.ToInt32(this._configuration["Jwt:ExpireMinutes"])),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
