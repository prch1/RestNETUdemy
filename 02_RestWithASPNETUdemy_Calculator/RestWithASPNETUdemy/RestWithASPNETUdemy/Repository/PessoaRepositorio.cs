using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Linq;

namespace RestWithASPNETUdemy.Repository
{
    public class PessoaRepositorio : GenericRepository<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(MSSQLContext context) : base(context){ }

        public Pessoa Desabilitar(int id)
        {
            if (!_context.Pessoas.Any(p => p.Id.Equals(id))) return null;
            var usuario = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(id));

            if(usuario != null)
            {
                usuario.Habilitado = false;
                try
                {
                    _context.Entry(usuario).CurrentValues.SetValues(usuario);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return usuario;
        }
    }
}
