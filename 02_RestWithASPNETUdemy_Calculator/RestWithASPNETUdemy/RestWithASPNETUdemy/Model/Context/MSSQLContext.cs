using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETUdemy.Model.Context
{
    public class MSSQLContext : DbContext
    {

        public MSSQLContext()
        {

        }

        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Livro> Livros { get; set; }    
    }
}
