using Microsoft.EntityFrameworkCore;
using SkillsTest.Lib;
using System.Linq;

namespace SkillsTest.Tests
{
    internal class DataContextHelper
    {
        /// <summary>
        /// Returns an instance of the In-Memory db context for testing
        /// </summary>
        /// <returns></returns>
        public static DataContext GetMockDb(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(name)
                .Options;

            var db = new DataContext(options);

            // Seed the database

            if (!db.Courses.Any())
            {
                db.Courses.AddRange(new[]
                {
                    new Course { Id = 1, Name = "Advanced Basketweaving" },
                    new Course { Id = 2, Name = "Math for Liberal Arts Majors" },
                    new Course { Id = 3, Name = "The Cosmos: An Introduction" }
                });

                db.SaveChanges();
            }

            if (!db.Students.Any())
            {
                foreach (var iteration in Enumerable.Range(1, 100))
                {
                    db.Students.Add(new Student
                    {
                        Id = iteration,
                        FirstName = "Test",
                        LastName = $"Student {iteration}",
                        Email = $"Test.Student{iteration}@StateUniversity.edu", // Added an email to test order by and filter by apis
                        Courses = db.Courses.Where(course => course.Id % iteration == 0).ToList()
                    });
                }

                db.SaveChanges();
            }

            return db;
        }
    }
}