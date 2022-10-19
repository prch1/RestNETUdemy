using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUsuarioRepositorio
    {
        Usuario ValidadeDaCredencial(UsuarioVO usuario);

        Usuario ValidadeDaCredencial(string nomeUsuario);

        Usuario AtualizarInformacoesToken(Usuario usuario);

        public bool RevokeToken(string nomeUsuario);
    }
}
