using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int Id { get; set; }

        [Column("NOME_USUARIO")]
        public string NomeUsuario  { get; set; }

        [Column("NOME_COMPLETO")]
        public string NomeCompleto { get; set; }

        [Column("SENHA")]
        public string Senha { get;set;}

        [Column("TOKEN")]
        public string Token { get; set; }

        [Column("VALIDADE_TOKEN")]
        public DateTime ValidadeToken { get; set; } 
    }
}
