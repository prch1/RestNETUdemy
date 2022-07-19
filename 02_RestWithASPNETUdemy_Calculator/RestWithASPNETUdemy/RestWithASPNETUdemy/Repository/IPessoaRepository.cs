using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPessoaRepository

    {
        Pessoa Criar(Pessoa pessoa);

        Pessoa BuscaPorId(int id);

        List<Pessoa> ListaTodos();

        Pessoa Atualizar(Pessoa pessoa);

        void Remover(int id);

        bool Exists(int id);
    }
}
