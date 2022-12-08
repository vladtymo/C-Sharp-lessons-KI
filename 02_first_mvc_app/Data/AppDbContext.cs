using _02_first_mvc_app.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_first_mvc_app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }

        public DbSet<User> Users { get; set; }
    }
}
