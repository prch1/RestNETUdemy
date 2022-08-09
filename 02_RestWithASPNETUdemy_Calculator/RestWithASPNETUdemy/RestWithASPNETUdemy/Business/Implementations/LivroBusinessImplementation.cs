using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class LivroBusinessImplementation : ILivroBusiness
    {

        private readonly IRepository<Livro> _repository;

        private readonly LivroConverter _converter;


        public LivroBusinessImplementation(IRepository<Livro> repository)
        {
            _repository = repository;
            _converter = new LivroConverter();
        }

        public LivroVO BuscaPorId(int id)
        {
            return _converter.Parse(_repository.BuscaPorId(id));
        }

        public List<LivroVO> ListaTodos()
        {
         return _converter.Parse(_repository.ListaTodos());
        }

        public LivroVO Criar(LivroVO livro)
        {
            var livroEntity = _converter.Parse(livro);
            livroEntity = _repository.Criar(livroEntity);
            return _converter.Parse(livroEntity);
        }


        public LivroVO Atualizar(LivroVO livro)
        {
            var livroEntity = _converter.Parse(livro);
            livroEntity = _repository.Atualizar(livroEntity);
            return _converter.Parse(livroEntity);
        }

        public void Remover(int id)
        {
             _repository.Remover(id);
        }
    }
}
