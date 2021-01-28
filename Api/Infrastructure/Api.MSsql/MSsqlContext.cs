using Microsoft.EntityFrameworkCore;

namespace Api.MSsql
{
    public class MSsqlContext : DbContext
    {
        public MSsqlContext(DbContextOptions<MSsqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        DbSet<UsersEntity> UsersEntities { get; set; }
    }
}
