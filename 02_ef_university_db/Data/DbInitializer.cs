using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ef_university_db.Data
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // - Dont need to invoke SaveChanges()
            // - Need to set the primary keys explicity

            Group gr1 = new() { Id = 1, Name = "Kyiv" };
            Group gr2 = new() { Id = 2, Name = "Kharkiv" };

            modelBuilder.Entity<Group>().HasData(gr1, gr2);

            Student st1 = new()
            {
                Id = 1,
                Name = "Igor",
                Birthdate = new DateTime(2003, 1, 3),
                AverageMark = 8.7F,
                Address = "Soborna street 5a, Rivne Ukraine",
                //Group = gr1,
                GroupId = 1,
            };
            Student st2 = new()
            {
                Id = 2,
                Name = "Olga",
                Birthdate = new DateTime(2005, 5, 10),
                AverageMark = 9.5F,
                Address = "Poshtova street 7b, Rivne Ukraine",
                //Group = gr2,
                GroupId = 2,
            };
            Student st3 = new()
            {
                Id = 3,
                Name = "Sasha",
                Birthdate = new DateTime(2005, 10, 3),
                AverageMark = 10.3F,
                Address = "Soborna street 5a, Rivne Ukraine",
                GroupId = 1,
            };
            Student st4 = new()
            {
                Id = 4,
                Name = "Viktoria",
                Birthdate = new DateTime(2004, 9, 10),
                AverageMark = 11.3F,
                Address = "Soborna street 10a, Rivne Ukraine",
                GroupId = 2,
            };

            modelBuilder.Entity<Student>().HasData(st1, st2, st3, st4);
        }
    }
}
