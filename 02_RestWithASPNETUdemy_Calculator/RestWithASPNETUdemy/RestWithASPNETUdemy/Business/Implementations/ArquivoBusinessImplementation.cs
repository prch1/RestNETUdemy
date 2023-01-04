using Microsoft.AspNetCore.Http;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class ArquivoBusinessImplementation : IArquivoBusiness
    {
        private readonly string _caminhoBase;
        private readonly IHttpContextAccessor _context;

        public ArquivoBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _caminhoBase = Directory.GetCurrentDirectory() + "\\UploadDir\\"; 
        }

        public byte[] ObterArquivo(string nomeArquivo)
        {
            var caminhoArquivo = _caminhoBase + nomeArquivo;
            return File.ReadAllBytes(caminhoArquivo);
        }

        public async Task<ArquivoDetalheVO> SalvarArquivo(IFormFile arquivo)
        {
            ArquivoDetalheVO arquivoDetalhe = new ArquivoDetalheVO();

            var arquivoTipo = Path.GetExtension(arquivo.FileName);
            var urlBase = _context.HttpContext.Request.Host;

            if(arquivoTipo.ToLower() ==".pdf" || arquivoTipo.ToLower() == ".jpg" ||
               arquivoTipo.ToLower() == ".png" || arquivoTipo.ToLower() == ".jpeg")
            {
                var nomeArquivo = Path.GetFileName(arquivo.FileName);
                if(nomeArquivo != null && nomeArquivo.Length > 0)
                {
                    var destino = Path.Combine(_caminhoBase,"", nomeArquivo);
                    arquivoDetalhe.NomeArquivo = nomeArquivo;
                    arquivoDetalhe.TipoArquivo = arquivoTipo;
                    arquivoDetalhe.ArquivoUrl = Path.Combine(urlBase + "/api/file/v1/" + arquivoDetalhe.NomeArquivo);

                    using var transmissao = new FileStream(destino, FileMode.Create);
                    await arquivo.CopyToAsync(transmissao);
                }
            }
            return arquivoDetalhe;
        }

        public async Task<List<ArquivoDetalheVO>> SalvarArquivos(IList<IFormFile> arquivos)
        {
            List<ArquivoDetalheVO> lista = new List<ArquivoDetalheVO>();

            foreach(var arquivo in arquivos)
            {
                lista.Add(await SalvarArquivo(arquivo));
            }
            return lista;
        }



    }
}
