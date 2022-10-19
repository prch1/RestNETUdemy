using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNETUdemy.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MSSQLContext _context;

        public UsuarioRepositorio(MSSQLContext context)
        {
            _context = context;
        }   

        public Usuario ValidadeDaCredencial(UsuarioVO usuario)
        {
            var passe = ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider());

            return _context.Usuarios.FirstOrDefault(u => (u.NomeUsuario == usuario.NomeUsuario) &&
                                                                           (u.Senha == passe)); 
        }

        public Usuario ValidadeDaCredencial(string nomeUsuario)
        {
            return _context.Usuarios.SingleOrDefault(u => (u.NomeUsuario == nomeUsuario));
        }

        private string ComputeHash(string senha, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(senha);
            Byte[] hashBytes = algorithm.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes);
        }


        public Usuario AtualizarInformacoesToken(Usuario usuario)
        {
           if(!_context.Usuarios.Any(i => i.Id.Equals(usuario.Id))) return null;
            
            var resultado = _context.Usuarios.SingleOrDefault(p => p.Id.Equals(usuario.Id));
            if (resultado != null)
            {
                try
                {
                    _context.Entry(resultado).CurrentValues.SetValues(usuario);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
                return resultado;
            }
            return resultado;
        }

        public bool RevokeToken(string nomeUsuario)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => (u.NomeUsuario == nomeUsuario));
            if (usuario is null) return false;
            usuario.Token = null;
            _context.SaveChanges();
            return true;

        }
    }
}
