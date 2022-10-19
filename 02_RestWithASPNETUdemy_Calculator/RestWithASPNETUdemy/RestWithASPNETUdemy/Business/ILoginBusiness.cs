using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidadorDeCredenciais (UsuarioVO usuario);

        TokenVO ValidadorDeCredenciais(TokenVO token);

        public bool RevokeToken(string nomeUsuario);


    }
}
