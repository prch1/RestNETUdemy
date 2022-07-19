using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PessoaRepositoryImplementation : IPessoaRepository
    {
        //private volatile int count;

        private MSSQLContext _context;

        public PessoaRepositoryImplementation(MSSQLContext context)
        {
            _context = context;
        }


        public bool Exists(int id)
        {
            return _context.Pessoas.Any(p => p.Id.Equals(id));
        }

        public Pessoa BuscaPorId(int id)
        {
            return _context.Pessoas.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Pessoa> ListaTodos()
        {
            return _context.Pessoas.ToList();
        }


        public Pessoa Criar(Pessoa pessoa)
        {        
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception )
            {
                throw; 
            }    
            return pessoa;
        }


        public Pessoa Atualizar(Pessoa pessoa)
        {
            if (!Exists(pessoa.Id)) return new Pessoa();
          
            var resultado = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(pessoa.Id));

            if(resultado != null)
            {
                try
                {
                    _context.Entry(resultado).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }  
            }
            return pessoa;
        }

        public void Remover(int id)
        {
            var resultado = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(id));

            if (resultado != null)
            {
                try
                {
                    _context.Pessoas.Remove(resultado);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
