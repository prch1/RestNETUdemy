using Microsoft.IdentityModel.Tokens;
using RestWithASPNETUdemy.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private TokenConfigurations _configuration;
        

        public TokenService(TokenConfigurations configuration)
        {
            _configuration = configuration;
        }

        public string GerarTokenDeAcesso(IEnumerable<Claim> claims)
        {
            var chaveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Segredo));
            var assinaturaCredencial = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);

            var opcaoToken = new JwtSecurityToken(
                issuer: _configuration.Emissor,
                audience: _configuration.Audiencia,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_configuration.Minutos),
                signingCredentials: assinaturaCredencial);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(opcaoToken);
            return tokenString;
        }

        public string GerarAtualizacaoToken()
        {
            var numeroRandomico = new byte[32];
            using (var nrd = RandomNumberGenerator.Create()) {
                nrd.GetBytes(numeroRandomico);
                return Convert.ToBase64String(numeroRandomico);
            };

        }

        public ClaimsPrincipal GetPrincipalDeExpiracaoToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Segredo)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
                                            SecurityAlgorithms.HmacSha256,
                                            StringComparison.InvariantCulture)) 
                throw new SecurityTokenException("Token Invalido");

            return principal;
        }
    }
}
