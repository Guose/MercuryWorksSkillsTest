using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillsTest.Lib
{
    public interface IStudentAPI
    {
        Student GetById(int id);
        IEnumerable<Student> GetAllStudentsOrderBy(string orderBy, string sortBy);
        IEnumerable<Student> GetAllStudentsFilteredBy(string firstName, string lastName, string email);

        //IEnumerable<Student> FindStudentsByCourse(string courseName);
        bool InsertNewStudent(Student student);
        bool UpdateStudentEmail(int id, string email);
        bool DeleteStudent(int id);

    }

    public class DbStudentAPI : IStudentAPI
    {
        private StudentHelper _studentHelper;
        public DataContext Db { get; set; }

        public Student GetById(int id)
        {
            return Db.Students.Where(student => student.Id == id).SingleOrDefault();
        }

        // Get All Students and order by either firstname, lastname or email,
        // if the specification is null then this api will return all students raw data
        public IEnumerable<Student> GetAllStudentsOrderBy(string orderBy, string sortBy)
        {
            List<Student> students = Db.Students.ToList();
            _studentHelper = new StudentHelper(students);
            
            return _studentHelper.OrderStudents(orderBy, sortBy);
        }

        // Get All Students and filter by either firstname, lastname or email,
        // or if all three are null or empty, return all students unfiltered.
        public IEnumerable<Student> GetAllStudentsFilteredBy(string firstName, string lastName, string email)
        {
            List<Student> students = Db.Students.ToList();
            _studentHelper = new StudentHelper(students);

            return _studentHelper.GetStudentsFiltered(firstName, lastName, email);
        }

        // Create new student
        public bool InsertNewStudent(Student student)
        {
            try
            {
                // check for null 
                if (student == null)
                    throw new ArgumentNullException();

                // Add student to DB and save changes
                Db.Students.Add(student);
                Db.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        // Patch Student email method
        public bool UpdateStudentEmail(int id, string updatedEmail)
        {
            try
            {
                // Get Student by id
                Student updatedStudent = Db.Students.FirstOrDefault(s => s.Id == id);

                // check for null 
                if (updatedStudent == null)
                    throw new ArgumentNullException();

                // update student's email, update database and save changes
                updatedStudent.Email = updatedEmail;
                Db.Students.Update(updatedStudent);
                Db.SaveChanges();

                return true;
            }
            catch {return false;}
        }

        // Delete student
        public bool DeleteStudent(int id)
        {
            try
            {
                // get student by id
                Student deleteStudent = Db.Students.FirstOrDefault(s => s.Id == id);

                //check for null
                if (deleteStudent == null)
                    throw new ArgumentNullException();

                Db.Students.Remove(deleteStudent);
                Db.SaveChanges();

                return true;
            }
            catch { return false; }
        }
    }
}
