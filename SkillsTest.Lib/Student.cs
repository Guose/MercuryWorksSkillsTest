using System;
using System.Collections.Generic;

namespace SkillsTest.Lib
{
    public class Student
    {
        public int Id { get; set; }

        public String LastName { get; set; }

        public String FirstName { get; set; }

        public String Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}