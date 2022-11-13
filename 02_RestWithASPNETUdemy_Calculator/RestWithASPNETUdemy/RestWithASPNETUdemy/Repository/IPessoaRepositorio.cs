using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPessoaRepositorio : IRepository<Pessoa>
    {
        Pessoa Desabilitar(int id);

    }
}
