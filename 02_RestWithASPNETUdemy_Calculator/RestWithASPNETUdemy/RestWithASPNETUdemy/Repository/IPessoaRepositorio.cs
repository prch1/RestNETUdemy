using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPessoaRepositorio : IRepository<Pessoa>
    {
        Pessoa Desabilitar(int id);

        List<Pessoa> BuscaPorNome(string primeiroNome, string sobreNome);
    }
}
