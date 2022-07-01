using Microsoft.EntityFrameworkCore;
using DiaryAPI.Models;
using DiaryAPI.ModelConfigurations;

namespace DiaryAPI.Data
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Note> Notes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Diary;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }



    }
}
