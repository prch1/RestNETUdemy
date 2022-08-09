using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface ILivroBusiness
    {
        LivroVO Criar(LivroVO Livro);

        LivroVO BuscaPorId(int id);

        List<LivroVO> ListaTodos();

        LivroVO Atualizar(LivroVO Livro);

        void Remover(int id);

    }
}
