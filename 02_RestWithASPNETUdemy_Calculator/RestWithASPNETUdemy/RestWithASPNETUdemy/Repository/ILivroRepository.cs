using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface ILivroRepository
    {
        Livro Criar(Livro Livro);

        Livro BuscaPorId(int id);

        List<Livro> ListaTodos();

        Livro Atualizar(Livro Livro);

        void Remover(int id);

        bool Exists(int id);
    }
}
