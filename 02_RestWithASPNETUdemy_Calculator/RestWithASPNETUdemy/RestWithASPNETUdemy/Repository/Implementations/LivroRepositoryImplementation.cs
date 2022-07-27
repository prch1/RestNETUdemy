using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class LivroRepositoryImplementation : ILivroRepository
    {

        private MSSQLContext _context;
      
        public LivroRepositoryImplementation(MSSQLContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.Livros.Any(l => l.Id.Equals(id));
        }

        public Livro BuscaPorId(int id)
        {
            return _context.Livros.SingleOrDefault(l => l.Id.Equals(id));    
        }

        public List<Livro> ListaTodos()
        {
            return _context.Livros.ToList();
        }

        public Livro Criar(Livro livro)
        {
           try
            {
                _context.Add(livro);
                _context.SaveChanges();

            }
            catch(Exception)
            {
                throw;
            }
            return livro;
        }



        public Livro Atualizar(Livro livro)
        {
            if (!Exists(livro.Id)) return null;

            var resultado = _context.Livros.SingleOrDefault(l => l.Id.Equals(livro.Id));

            if(resultado != null)
            {
                try
                {
                    _context.Entry(resultado).CurrentValues.SetValues(livro);
                    _context.SaveChanges();
                }
                catch(Exception)
                {
                    throw;
                }
            }

            return livro;
        }

        public void Remover(int id)
        {
            var resultado = _context.Livros.SingleOrDefault(l =>l.Id.Equals(id));

            if(resultado != null)
            {
                try
                {
                    _context.Livros.Remove(resultado);
                    _context.SaveChanges();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }
    }
}
