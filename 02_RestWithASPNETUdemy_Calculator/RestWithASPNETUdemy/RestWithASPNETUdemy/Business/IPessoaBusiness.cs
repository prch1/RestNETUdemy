using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPessoaBusiness

    {
        PessoaVO Criar(PessoaVO pessoa);

        PessoaVO BuscaPorId(int id);

        List<PessoaVO> BuscaPorNome(string primeiroNome, string sobreNome);

        List<PessoaVO> ListaTodos();

        PagedSearchVO<PessoaVO> BuscaComPaginacao(string nome, string direcionadorOrdenacao, int tamanhoDaPagina, int pagina);

        PessoaVO Atualizar(PessoaVO pessoa);

        PessoaVO Desabilitar(int id);

        void Remover(int id);
    }
}
