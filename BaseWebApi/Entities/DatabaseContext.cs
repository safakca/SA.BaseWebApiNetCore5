using Microsoft.EntityFrameworkCore;

namespace BaseWebApi.Entities
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
