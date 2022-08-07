using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class LivroBusinessImplementation : ILivroBusiness
    {

        private readonly IRepository<Livro> _repository;


        public LivroBusinessImplementation(IRepository<Livro> repository)
        {
            _repository = repository;
        }

        public Livro BuscaPorId(int id)
        {
            return _repository.BuscaPorId(id);
        }

        public List<Livro> ListaTodos()
        {
         return _repository.ListaTodos();
        }


        public Livro Criar(Livro livro)
        {
            return _repository.Criar(livro);
        }


        public Livro Atualizar(Livro livro)
        {
            return _repository.Atualizar(livro);
        }

        public void Remover(int id)
        {
             _repository.Remover(id);
        }
    }
}
