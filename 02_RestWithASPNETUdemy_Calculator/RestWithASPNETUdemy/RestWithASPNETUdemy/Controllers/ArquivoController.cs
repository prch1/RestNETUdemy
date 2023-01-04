using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ArquivoController : Controller
    {
        private readonly IArquivoBusiness _arquivoBusiness;

        public ArquivoController(IArquivoBusiness arquivoBusiness)
        {
            _arquivoBusiness = arquivoBusiness;
        }


        [HttpPost("uploadArquivo")]
        [ProducesResponseType((200), Type = typeof(ArquivoDetalheVO))]
        [ProducesResponseType((400), Type = typeof(ArquivoDetalheVO))]
        [ProducesResponseType((401), Type = typeof(ArquivoDetalheVO))]
        [Produces("application/json")]
        public async Task<IActionResult> UploadUmArquivo([FromForm] IFormFile arquivo)
        {
            ArquivoDetalheVO detalhe = await _arquivoBusiness.SalvarArquivo(arquivo);
            return new OkObjectResult(detalhe);
        }

        [HttpPost("uploadMultiplosArquivos")]
        [ProducesResponseType((200), Type = typeof(List<ArquivoDetalheVO>))]
        [ProducesResponseType((400), Type = typeof(List<ArquivoDetalheVO>))]
        [ProducesResponseType((401), Type = typeof(List<ArquivoDetalheVO>))]
        [Produces("application/json")]
        public async Task<IActionResult> UploadMultiplosArquivo([FromForm] List<IFormFile> arquivos)
        {
            List<ArquivoDetalheVO> detalhes = await _arquivoBusiness.SalvarArquivos(arquivos);
            return new OkObjectResult(detalhes);
        }


        [HttpGet("downloadArquivo/{nomeArquivo}")]
        [ProducesResponseType((200), Type = typeof(byte[]))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<IActionResult> ObterArquivoAsync(string nomeArquivo)
        {
            byte[] buffer = _arquivoBusiness.ObterArquivo(nomeArquivo);

            if (buffer != null)
            {
                HttpContext.Response.ContentType = 
                    $"application/{Path.GetExtension(nomeArquivo).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer,0,buffer.Length);
            }
            return new ContentResult();
        }

    }
}
