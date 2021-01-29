using Microsoft.EntityFrameworkCore;

namespace Api.MSsql
{
    public class MSsqlContext : DbContext
    {
        public DbSet<UsersEntity> UsersEntities { get; set; }

        public MSsqlContext(DbContextOptions<MSsqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
