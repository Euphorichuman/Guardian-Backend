using Guardian.System.Infraestructure.MySqlDb.Entities;

namespace Guardian.System.Infraestructure.MySqlDb.Context
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<DbHero> Heroes { get; set; }

        public DbSet<DbVillain> Villains { get; set; }
    }
}
