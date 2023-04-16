using BaseApplicationModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseApplicationModule.Infra
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
