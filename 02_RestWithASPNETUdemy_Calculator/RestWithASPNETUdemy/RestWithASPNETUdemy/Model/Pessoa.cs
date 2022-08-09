using RestWithASPNETUdemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("Pessoa")]
    public class Pessoa : BaseEntity
    {   
        [Column("PRIMEIRO_NOME")]
        public string PrimeiroNomeA { get; set; }
        [Column("SOBRE_NOME")]
        public string SobreNome { get; set; }
        [Column("ENDERECO")]
        public string Endereco { get; set; }
        [Column("GENERO")]
        public string Genero { get; set; }  
    }
}
