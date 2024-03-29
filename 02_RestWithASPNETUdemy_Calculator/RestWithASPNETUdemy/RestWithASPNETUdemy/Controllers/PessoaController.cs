﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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
        [ProducesResponseType((200),Type = typeof(List<PessoaVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        { 
          return Ok(_pessoaBusiness.ListaTodos());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaBusiness.BuscaPorId(id);
            if(pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpGet("buscarPessoaPorNome")]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] string primeiroNome, [FromQuery] string sobreNome)
        {
            var pessoa = _pessoaBusiness.BuscaPorNome(primeiroNome, sobreNome);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }


        [HttpGet("{direcionadorOrdenacao}/{tamanhoPagina}/{pagina}")]
        [ProducesResponseType((200), Type = typeof(List<PessoaVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(
            [FromQuery] string nome,
              string direcionadorOrdenacao,
              int tamanhoPagina,
              int pagina)
        {
            return Ok(_pessoaBusiness.BuscaComPaginacao(nome, direcionadorOrdenacao, tamanhoPagina, pagina));
        }


        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(int id)
        {
            var pessoa = _pessoaBusiness.Desabilitar(id);
            return Ok(pessoa);
        }


        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PessoaVO pessoa)
        { 
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Criar(pessoa));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Atualizar(pessoa));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _pessoaBusiness.Remover(id);
            return NoContent();
        }

    }
}
