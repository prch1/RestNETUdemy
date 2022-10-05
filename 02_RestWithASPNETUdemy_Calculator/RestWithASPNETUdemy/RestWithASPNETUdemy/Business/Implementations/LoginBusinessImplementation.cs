using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATA_FORMATO = "yyyy-MM-dd HH:mm:ss";
        private TokenConfigurations _configuracao;
        private IUsuarioRepositorio _repositorio;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfigurations configuracao, IUsuarioRepositorio repositorio, ITokenService tokenService)
        {
            _configuracao = configuracao;
            _repositorio = repositorio;
            _tokenService = tokenService;
        }

        public TokenVO ValidadorDeCredenciais(UsuarioVO credencialUsuario)
        {
            var usuario = _repositorio.ValidadeDaCredencial(credencialUsuario);

            if (usuario == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,usuario.NomeUsuario)
            };

            var tokenDeAcesso = _tokenService.GerarTokenDeAcesso(claims);
            var refreshToken = _tokenService.GerarAtualizacaoToken();

            usuario.Token = refreshToken;
            usuario.ValidadeToken = DateTime.Now.AddDays(_configuracao.DiasParaExpirar);

            _repositorio.AtualizarInformacoesToken(usuario);

            DateTime dataDaCriacao = DateTime.Now;
            DateTime dataDaExpiracao = dataDaCriacao.AddMinutes(_configuracao.Minutos);

            return new TokenVO(
                  true,
                  dataDaCriacao.ToString(DATA_FORMATO),
                  dataDaExpiracao.ToString(DATA_FORMATO),
                  tokenDeAcesso,
                  refreshToken     
                );
        }

    }
}
