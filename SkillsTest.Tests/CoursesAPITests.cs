using SkillsTest.Lib;
using Xunit;

namespace SkillsTest.Tests
{
    public class CoursesAPITests
    {
        private DbCourseAPI api = new DbCourseAPI
        {
            Db = DataContextHelper.GetMockDb(nameof(CoursesAPITests))
        };

        [Fact]
        public void Can_Get_Course_With_Id_1()
        {
            var course = api.GetById(1);

            Assert.NotNull(course);
        }

        [Fact]
        public void Can_GetAll_Courses_Pageable()
        {
            var courses = api.GetAllCoursesPageable(1, 1);

            Assert.NotNull(courses);
        }

        [Fact]
        public void Can_Delete_Course_With_Id_1()
        {
            Assert.True(api.DeleteCourse(1));
        }

        [Fact]
        public void Can_Create_Course()
        {
            var newCourse = new Course
            {
                Id = 10,
                Name = "Cloud Computing Course",
            };

            bool isCreated = api.CreateNewCourse(newCourse);

            Assert.True(isCreated);
        }

        [Fact]
        public void Can_Update_Course()
        {
            var course = api.GetByName("Advanced Basketweaving");

            bool isUpdated = api.UpdateNameOfCourse("Beginners Basketweaving", course.Id);

            Assert.True(isUpdated);
        }

        [Fact]
        public void Cannot_Update_Course()
        {
            var course = api.GetByName("Novice Basketweaving");

            bool isUpdated = course == null 
                ? api.UpdateNameOfCourse("Beginners Basketweaving", 0)
                : api.UpdateNameOfCourse("Beginners Basketweaving", course.Id);

            Assert.False(isUpdated);
        }
    }
}