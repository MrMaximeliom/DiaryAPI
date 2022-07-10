using Microsoft.EntityFrameworkCore;
using DiaryAPI.Models;
using DiaryAPI.ModelConfigurations;

namespace DiaryAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Note> Notes { get; set; } = null!;
        public ApplicationDBContext() 
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }



    }
}
