using Microsoft.AspNetCore.Http;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business
{
    public interface IArquivoBusiness
    {
        public byte[] ObterArquivo(string nomeArquivo);

        public Task<ArquivoDetalheVO> SalvarArquivo(IFormFile arquivo);

        public Task<List<ArquivoDetalheVO>> SalvarArquivos(IList<IFormFile> arquivos);
    }
}
