using RestWithASPNETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Criar(T item);

        T BuscaPorId(int id);

        List<T> ListaTodos();

        T Atualizar(T item);

        void Remover(int id);

        bool Exists(int id);

        List<T> BuscaComPaginacao(string query);

        int GetCount(string query);

    }
}
