using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        //private volatile int count;

        private readonly IPessoaRepositorio _repository;

        private readonly PessoaConverter _converter;

      //  private MSSQLContext _repository;

        public PessoaBusinessImplementation(IPessoaRepositorio repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();

        }

        public PessoaVO BuscaPorId(int id)
        {
            return _converter.Parse(_repository.BuscaPorId(id));
        }

        public List<PessoaVO> BuscaPorNome(string primeiroNome, string sobreNome)
        {
            return _converter.Parse(_repository.BuscaPorNome(primeiroNome, sobreNome));
        }

        public List<PessoaVO> ListaTodos()
        {
            return _converter.Parse(_repository.ListaTodos());
        }

        public PagedSearchVO<PessoaVO> BuscaComPaginacao(string nome, string direcionadorOrdenacao,
                                                        int tamanhoDaPagina, int pagina)
        {
            
            var ordenacao = (!string.IsNullOrWhiteSpace(direcionadorOrdenacao)) && !direcionadorOrdenacao.Equals("desc") ? "asc" : "desc";
            var size = (tamanhoDaPagina < 1) ? 10 : tamanhoDaPagina;
            var offset = pagina > 0 ? (pagina - 1) * size : 0;
            string query = "";
          
            if(size == 0)
            {
                 query = query + @"SELECT * FROM PESSOA P WHERE 1 = 1";
            }
            else
            {
                 query = query + $@"SELECT top({size}) * FROM PESSOA P WHERE 1 = 1";
            } 
            

            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query + $"AND P.PRIMEIRO_NOME LIKE '%{nome}%'";
                query = query + $"ORDER BY P.PRIMEIRO_NOME {ordenacao} ";
                //query = query + $"ORDER BY P.PRIMEIRO_NOME {ordenacao} LIMIT {size} OFFSET {offset} ";
            }

            string countQuery = @"SELECT COUNT(*) FROM PESSOA P WHERE 1 =1 ";

            if (!string.IsNullOrWhiteSpace(nome))
            {
                countQuery = countQuery + $"AND P.PRIMEIRO_NOME LIKE '%{nome}%'";
            }
            

            var pessoas = _repository.BuscaComPaginacao(query);
            int total = _repository.GetCount(countQuery);

            return new PagedSearchVO<PessoaVO> {
                PaginaAtual = pagina,
                Lista = _converter.Parse(pessoas),
                TamanhoDaPagina = tamanhoDaPagina,
                OrdenacaoDirecionada = ordenacao,
                TotalResultado = total
            };
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

        public PessoaVO Desabilitar(int id)
        {
           var pessoaEntity = _repository.Desabilitar(id);
            return _converter.Parse(pessoaEntity);
        }

        public void Remover(int id)
        {
             _repository.Remover(id);
        }

       
    }
}
