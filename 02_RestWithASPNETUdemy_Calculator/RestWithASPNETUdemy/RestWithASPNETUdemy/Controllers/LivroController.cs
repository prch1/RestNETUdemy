using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
  
    public class LivroController : Controller
    {
        private readonly ILogger<LivroController> _logger;
        private ILivroBusiness _livroBusiness;

        public LivroController(ILogger<LivroController> logger, ILivroBusiness livroService)
        {
            _logger = logger;
            _livroBusiness = livroService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_livroBusiness.ListaTodos());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var livro = _livroBusiness.BuscaPorId(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return Ok(_livroBusiness.Criar(livro));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return Ok(_livroBusiness.Atualizar(livro));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _livroBusiness.Remover(id);
            return NoContent();
        }

    }
}
