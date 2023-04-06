using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Model;

namespace SimpleApiRest.Infra
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
        }

    }


}
