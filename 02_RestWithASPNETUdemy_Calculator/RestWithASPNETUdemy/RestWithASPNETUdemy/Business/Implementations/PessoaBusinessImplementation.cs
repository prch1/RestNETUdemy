using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        //private volatile int count;

        private readonly IRepository<Pessoa> _repository;

        private readonly PessoaConverter _converter;

      //  private MSSQLContext _repository;

        public PessoaBusinessImplementation(IRepository<Pessoa> repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();

        }

        public PessoaVO BuscaPorId(int id)
        {
            return _converter.Parse(_repository.BuscaPorId(id));
        }

        public List<PessoaVO> ListaTodos()
        {
            return _converter.Parse(_repository.ListaTodos());
        }

        public PessoaVO Criar(PessoaVO pessoa)
        {
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Criar(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public PessoaVO Atualizar(PessoaVO pessoa)
        {

            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Atualizar(pessoaEntity);

            return _converter.Parse(pessoaEntity);
        }

        public void Remover(int id)
        {
             _repository.Remover(id);
        }

    }
}
