using Microsoft.IdentityModel.Tokens;
using RapidPay.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class TokenService : ITokenService
    {
        readonly string secret;
        readonly string issuer;
        readonly string audience;
        readonly int duration;
        public TokenService(string secret, string issuer, string audience, int duration) => 
            (this.secret, this.issuer, this.audience, this.duration) = (secret, issuer, audience, duration);
        public string GenerateSecurityToken(string user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signinCredentials);
            var claims = new[] {
               new Claim("name" ,user)
            };
            //var payload = new JwtPayload(claims);
            var payload = new JwtPayload(issuer, audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(duration));
            var token = new JwtSecurityToken(header, payload);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
