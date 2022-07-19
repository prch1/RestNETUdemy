using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPessoaBusiness

    {
        Pessoa Criar(Pessoa pessoa);

        Pessoa BuscaPorId(int id);

        List<Pessoa> ListaTodos();

        Pessoa Atualizar(Pessoa pessoa);

        void Remover(int id);
    }
}
