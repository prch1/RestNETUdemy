using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
       
        protected MSSQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T BuscaPorId(int id)
        {
            return dataset.SingleOrDefault(i => i.Id.Equals(id));
        }

        public List<T> ListaTodos()
        {
            return dataset.ToList();
        }

        public T Criar(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public T Atualizar(T item)
        {
            var resultado = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (resultado != null)
            {
                try
                {
                    _context.Entry(resultado).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    
                }
                catch (Exception)
                {
                    throw;
                }
                return resultado;
            }

            else
            {
                return null;
            }
        }

        public void Remover(int id)
        {
            var resultado = dataset.SingleOrDefault(p => p.Id.Equals(id));

            if(resultado != null)
            {
                try
                {
                    dataset.Remove(resultado);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
          
            }  
        }

        public bool Exists(int id)
        {
            return dataset.Any(i => i.Id.Equals(id));
        }

        public List<T> BuscaComPaginacao(string query)
        {
            return dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using(var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using(var comando = connection.CreateCommand())
                {
                    comando.CommandText = query;
                    result = comando.ExecuteScalar().ToString();

                }
            }

            return int.Parse(result);
        }
    }
   
}
