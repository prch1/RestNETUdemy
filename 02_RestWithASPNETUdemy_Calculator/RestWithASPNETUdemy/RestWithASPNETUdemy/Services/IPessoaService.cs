using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public interface IPessoaService
    {
        Pessoa Criar(Pessoa pessoa);

        Pessoa BuscaPorId(int id);

        List<Pessoa> ListaTodos();

        Pessoa Atualizar(Pessoa pessoa);

        void Remover(int id);
    }
}
