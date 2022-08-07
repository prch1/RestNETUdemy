using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        //private volatile int count;

        private readonly IRepository<Pessoa> _repository;

      //  private MSSQLContext _repository;

        public PessoaBusinessImplementation(IRepository<Pessoa> repository)
        {
            _repository = repository;

        }

        public Pessoa BuscaPorId(int id)
        {
            return _repository.BuscaPorId(id);
        }

        public List<Pessoa> ListaTodos()
        {
            return _repository.ListaTodos();
        }

        public Pessoa Criar(Pessoa pessoa)
        {         
            return _repository.Criar(pessoa);
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            return _repository.Atualizar(pessoa);
        }

        public void Remover(int id)
        {
             _repository.Remover(id);
        }

    }
}
