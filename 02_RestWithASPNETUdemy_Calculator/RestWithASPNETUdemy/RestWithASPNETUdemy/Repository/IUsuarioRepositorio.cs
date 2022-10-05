using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUsuarioRepositorio
    {
        Usuario ValidadeDaCredencial(UsuarioVO usuario);

        Usuario AtualizarInformacoesToken(Usuario usuario);
    }
}
