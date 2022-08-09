using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class PessoaConverter : IParse<PessoaVO, Pessoa>, IParse<Pessoa, PessoaVO>
    {
        public Pessoa Parse(PessoaVO origem)
        {
           if(origem == null)   return null;
            return new Pessoa
            {
                Id = origem.Id,
                PrimeiroNomeA = origem.PrimeiroNomeA,
                SobreNome = origem.SobreNome,
                Endereco = origem.Endereco,
                Genero = origem.Genero
            };
        }

        public PessoaVO Parse(Pessoa origem)
        {
            if (origem == null) return null;
            return new PessoaVO
            {
                Id = origem.Id,
                PrimeiroNomeA = origem.PrimeiroNomeA,
                SobreNome = origem.SobreNome,
                Endereco = origem.Endereco,
                Genero = origem.Genero
            };
        }

        public List<Pessoa> Parse(List<PessoaVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<PessoaVO> Parse(List<Pessoa> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
