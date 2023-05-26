using SkillsTest.Lib;
using Xunit;

namespace SkillsTest.Tests
{
    public class StudentAPITests
    {
        private DbStudentAPI api = new DbStudentAPI
        {
            Db = DataContextHelper.GetMockDb(nameof(StudentAPITests))
        };

        [Fact]
        public void Can_Get_Student_With_Id_1()
        {
            var student = api.GetById(1);

            Assert.NotNull(student);
        }

        [Fact]
        public void Can_Delete_Student_With_Id_1()
        {
            Assert.True(api.DeleteStudent(1));
        }

        [Fact]
        public void Can_Create_Student()
        {
            var newStudent = new Student
            {
                Id = 200,
                FirstName = "Test",
                LastName = "Student 200",
                Email = "Test.Student200@StateUniversity.edu",
            };

            bool isCreated = api.InsertNewStudent(newStudent);
            Assert.True(isCreated);
        }

        #region Email Validation Tests
        [Fact]
        public void Can_Get_Student_With_Id_1_ValidateEmail()
        {
            var student = api.GetById(1);

            Assert.True(StudentHelper.ValidateEmail(student.Email));
        }

        [Fact]
        public void Cannot_Get_Student_With_Id_1_ValidateEmail()
        {
            var student = api.GetById(1);

            Assert.False(StudentHelper.ValidateEmail(@"thisEmailWillNotWork@,1%4"));
        }
        #endregion

        #region FILTERBY Tests
        [Fact]
        public void Can_Get_Student_FilteredBy_Firstname()
        {
            var student = api.GetAllStudentsFilteredBy("Test", "", "");

            Assert.NotNull(student);
        }

        [Fact]
        public void Can_Get_Student_FilteredBy_Lastname()
        {
            var student = api.GetAllStudentsFilteredBy("", "Student 1", "");

            Assert.NotNull(student);
        }

        [Fact]
        public void Can_Get_Student_FilteredBy_Email()
        {
            var student = api.GetAllStudentsFilteredBy("", "", "Test.Student1@StateUniversity.edu");

            Assert.NotNull(student);
        }
        #endregion

        #region ORDERBY Tests
        [Fact]
        public void Can_Get_All_Students_OrderedBy_FirstName_DESC()
        {
            var students = api.GetAllStudentsOrderBy("FirstName", "desc");

            Assert.NotNull(students);
        }

        [Fact]
        public void Can_Get_All_Students_OrderedBy_LastName_ASC()
        {
            var students = api.GetAllStudentsOrderBy("LastName", "asc");

            Assert.NotNull(students);
        }

        [Fact]
        public void Can_Get_All_Students_OrderedBy_Email_ASC()
        {
            var students = api.GetAllStudentsOrderBy("email", "asc");

            Assert.NotNull(students);
        }

        [Fact]
        public void Can_Get_All_Students_OrderedBy_NotSpecified()
        {
            var students = api.GetAllStudentsOrderBy("", "");

            Assert.NotNull(students);
        }

        [Fact]
        public void Cannot_Get_All_Students_OrderedBy_Returns_NULL()
        {
            var students = api.GetAllStudentsOrderBy(null, null);

            Assert.Null(students);
        }
        #endregion
    }
}