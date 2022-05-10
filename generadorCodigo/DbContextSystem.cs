using Microsoft.EntityFrameworkCore;

namespace generadorCodigo
{
    public class DbContextSystem:DbContext
    {

        public DbContextSystem()
        {

        }

        public DbContextSystem(DbContextOptions<DbContextSystem> options):base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=INABVE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }

}
