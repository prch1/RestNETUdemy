using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface ILivroBusiness
    {
        Livro Criar(Livro Livro);

        Livro BuscaPorId(int id);

        List<Livro> ListaTodos();

        Livro Atualizar(Livro Livro);

        void Remover(int id);

    }
}
