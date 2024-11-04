using ToDoTask.DataBases.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoTask.DataBases.Entitys;
using System.IO;

namespace ToDoTask.DataBases
{
    public class ApplicationSQLliteContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }

        public DbContextOptions DbContextOptions { get; set; }

        public ApplicationSQLliteContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory() + @"\DataBases\");
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            DbContextOptions = optionsBuilder.UseSqlite(connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}