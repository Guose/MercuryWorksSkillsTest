using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace SkillsTest.Lib
{
    public class StudentHelper
    {
        private readonly List<Student> _students;

        public StudentHelper()
        {
            
        }
        public StudentHelper(List<Student> students)
        {
            _students = students;
        }

        public List<Student> GetStudentsFiltered(string firstName, string lastName, string email)
        {
            if (_students == null)
                throw new ArgumentNullException();

            if (!string.IsNullOrEmpty(firstName))
                return _students.Where(s => s.FirstName == firstName).ToList();

            if (!string.IsNullOrEmpty(lastName))
                return _students.Where(s => s.LastName == lastName).ToList();

            if (!string.IsNullOrEmpty(email))
                return _students.Where(s => s.Email == email).ToList();

            return _students;
        }
        public List<Student> OrderStudents(string filterBy, string sortBy)
        {
            if (_students == null)
                throw new ArgumentNullException();

            try
            {
                switch (filterBy.ToLower().Trim())
                {
                    case "firstname":
                        return sortBy.ToUpper().Trim() == "ASC"
                            ? _students.OrderBy(f => f.FirstName).ToList()
                            : _students.OrderByDescending(f => f.FirstName).ToList();
                    case "lastname":
                        return sortBy.ToUpper().Trim() == "ASC"
                            ? _students.OrderBy(l => l.LastName).ToList()
                            : _students.OrderByDescending(l => l.LastName).ToList();
                    case "email":
                        return sortBy.ToUpper().Trim() == "ASC"
                            ? _students.OrderBy(e => e.Email).ToList()
                            : _students.OrderByDescending(e => e.Email).ToList();
                    default:
                        return _students;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION: {ex.Message}");
                return null;
            }

            
        }

        public static bool ValidateEmail(string email)
        {
            if (email == null) return false;

            string pattern = @"^[A-Za-z0-9_.+-]+@[A-Za-z0-9-.]+$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static bool IsUniqueEmail(List<Student> students, string email)
        {
            if (email == null) return false;

            bool isUnique = !students.Any(s => s.Email == email);
            return isUnique;
        }
    }
}
