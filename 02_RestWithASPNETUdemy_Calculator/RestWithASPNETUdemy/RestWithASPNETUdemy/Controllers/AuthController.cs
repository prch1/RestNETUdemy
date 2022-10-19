using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]

    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioVO usuario)
        {
            if (usuario == null) return BadRequest("Requisição Inválida");
            var token = _loginBusiness.ValidadorDeCredenciais(usuario);
            if (token == null) return Unauthorized();
            return Ok(token);

        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo == null) return BadRequest("Requisição Inválida");
            var token = _loginBusiness.ValidadorDeCredenciais(tokenVo);
            if (token == null) return BadRequest("Requisição Inválida");
            return Ok(token);

        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var nomeUsuario = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(nomeUsuario);

            if (!result) return BadRequest("Requisição Inválida");
            return NoContent();

        }

    }
}
