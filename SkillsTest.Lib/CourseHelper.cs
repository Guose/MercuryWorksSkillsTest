using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTest.Lib
{
    public class CourseHelper
    {
        public static bool IsUniqueCourseName(List<Course> courses, string name)
        {
            if (name == null) return false;

            bool isUnique = !courses.Any(s => s.Name == name);
            return isUnique;
        }
    }
}
