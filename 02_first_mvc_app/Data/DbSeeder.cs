using _02_first_mvc_app.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_first_mvc_app.Data
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // - Dont need to invoke SaveChanges()
            // - Need to set the primary keys explicity

            List<User> users = new List<User>()
            {
                new User() {Id = 1, Name = "Bob", Email = "saper@gmail.com", BirthDate = DateTime.Now},
                new User() {Id = 2, Name = "Vlad", Email = "blabla@gmail.com", BirthDate = DateTime.Now},
                new User() {Id = 3, Name = "John", Email = "mister@ukr.net", BirthDate = DateTime.Now},
                new User() {Id = 4, Name = "Lilia", Email = "developer@gmail.com", BirthDate = DateTime.Now}
            };
            
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
