using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASPNETUdemy.Services
{
    public interface ITokenService
    {
        string GerarTokenDeAcesso(IEnumerable<Claim> claims);

        string GerarAtualizacaoToken();

        ClaimsPrincipal GetPrincipalDeExpiracaoToken(string token);


    }
}
