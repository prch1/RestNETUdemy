namespace RestWithASPNETUdemy.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool autenticado, string criado, string expiracao, string tokenDeAcesso, string refreshToken)
        {
            Autenticado = autenticado;
            Criado = criado;
            Expiracao = expiracao;
            TokenDeAcesso = tokenDeAcesso;
            RefreshToken = refreshToken;
        }

        public bool Autenticado { get; set; }

        public string Criado { get; set; }

        public string Expiracao { get; set; }

        public string TokenDeAcesso { get; set; }

        public string RefreshToken { get; set; }

    }
}
