using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public interface IPessoaService
    {
        Pessoa Criar(Pessoa pessoa);

        Pessoa BuscaPorId(long id);

        List<Pessoa> ListaTodos();

        Pessoa Atualizar(Pessoa pessoa);

        void Remover(long id);
    }
}
