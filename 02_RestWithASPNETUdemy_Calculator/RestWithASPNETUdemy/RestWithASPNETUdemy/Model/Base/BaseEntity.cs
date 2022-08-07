using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model.Base
{
    public class BaseEntity
    {
        [Column("ID")]

        public int Id { get; set; }
    }
}
