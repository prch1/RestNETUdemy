using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;

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

    }
}
