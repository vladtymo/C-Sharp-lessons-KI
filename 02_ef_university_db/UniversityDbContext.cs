using _02_ef_university_db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace _02_ef_university_db
{
    // Task: create university database
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated(); // create db if not exist
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=OnlineUniversityDb2022; Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ------------- Entity Configurations (Fluent API) -------------

            // One to Many (1...*)
            modelBuilder.Entity<Student>().HasOne(x => x.Group)
                                          .WithMany(x => x.Students)
                                          .HasForeignKey(x => x.GroupId);

            // Many to Many (*...*)
            modelBuilder.Entity<Group>().HasMany(x => x.Subjects).WithMany(x => x.Groups);

            // ------------- Database initialization -------------
            
            //DbInitializer.Seed(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}