using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PessoaController : ControllerBase
    {

        private readonly ILogger<PessoaController> _logger;
        private IPessoaBusiness _pessoaBusiness;

        public PessoaController(ILogger<PessoaController> logger, IPessoaBusiness pessoaService)
        {
            _logger = logger;
            _pessoaBusiness = pessoaService;
        }


        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        { 
          return Ok(_pessoaBusiness.ListaTodos());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaBusiness.BuscaPorId(id);
            if(pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PessoaVO pessoa)
        { 
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Criar(pessoa));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Atualizar(pessoa));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pessoaBusiness.Remover(id);
            return NoContent();
        }

    }
}
