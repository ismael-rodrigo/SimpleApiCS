using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Domain.Entities;

namespace SimpleApiRest.Infra
{
    public class AppDataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseSqlite(connectionString: "DataSource=External/DataBase/app.db;Cache=Shared");
        }

    }


}
