using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Domain.Models;

namespace SimpleApiRest.Infra
{
    public class AppDataContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
        }

    }


}
