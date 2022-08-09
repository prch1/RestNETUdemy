using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPessoaBusiness

    {
        PessoaVO Criar(PessoaVO pessoa);

        PessoaVO BuscaPorId(int id);

        List<PessoaVO> ListaTodos();

        PessoaVO Atualizar(PessoaVO pessoa);

        void Remover(int id);
    }
}
