using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class LivroConverter : IParse<LivroVO, Livro>, IParse<Livro, LivroVO>
    {
        public Livro Parse(LivroVO origem)
        {
            if (origem == null) return null;
            return new Livro
            {
                Id = origem.Id,
                Titulo = origem.Titulo,
                Preco = origem.Preco,
                Editora =  origem.Editora
            };
        }

        public LivroVO Parse(Livro origem)
        {
            if (origem == null) return null;
            return new LivroVO
            {
                Id = origem.Id,
                Titulo = origem.Titulo,
                Preco = origem.Preco,
                Editora = origem.Editora
            };
        }

        public List<Livro> Parse(List<LivroVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<LivroVO> Parse(List<Livro> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
