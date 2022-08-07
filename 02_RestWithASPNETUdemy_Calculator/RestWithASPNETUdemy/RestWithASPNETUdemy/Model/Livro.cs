using RestWithASPNETUdemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("Livro")]
    public class Livro : BaseEntity
    {    
        [Column("TITULO")]
        public string Titulo { get; set; }
        [Column("EDITORA")]
        public string Editora { get; set; }
        [Column("PRECO")]
        public decimal Preco { get; set; }  
    }
}
