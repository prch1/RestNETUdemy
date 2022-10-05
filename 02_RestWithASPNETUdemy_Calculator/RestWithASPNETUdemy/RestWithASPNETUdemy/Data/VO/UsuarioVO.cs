using System;

namespace RestWithASPNETUdemy.Data.VO
{
    public class UsuarioVO
    {
        public int Id { get; set; }

        public string NomeUsuario { get; set; }

        public string NomeCompleto { get; set; }

        public string Senha { get; set; }

        public string Token { get; set; }

        public DateTime ValidadeToken { get; set; }
    }
}

