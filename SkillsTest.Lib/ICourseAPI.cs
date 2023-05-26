using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SkillsTest.Lib
{
    public interface ICourseAPI
    {
        Course GetById(int id);
        Course GetByName(string name);
        IEnumerable<Course> GetAllCoursesPageable(int page, int pagesize);
        bool UpdateNameOfCourse(string name, int id);
        bool CreateNewCourse(Course course);
        bool DeleteCourse(int id);
    }

    public class DbCourseAPI : ICourseAPI
    {
        public DataContext Db { get; set; }


        // Insert(Post) new course into Db
        public bool CreateNewCourse(Course course)
        {
            try
            {
                // check for null
                if (course == null)
                    return false;

                // Add course to DB and save changes
                Db.Courses.Add(course);
                Db.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        // Delete course from Db
        public bool DeleteCourse(int id)
        {
            try
            {
                var deleteCourseById = Db.Courses.FirstOrDefault(c => c.Id == id);

                if (deleteCourseById == null)
                    return false;

                Db.Courses.Remove(deleteCourseById);
                Db.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        // Get courses using pagination parameters
        public IEnumerable<Course> GetAllCoursesPageable(int page, int pagesize)
        {
            List<Course> courses = Db.Courses.ToList();

            // check for null
            if (courses != null && courses.Count() > 0)
            {
                if (page > 0 && pagesize > 0)
                {
                    int offset = (page - 1) * pagesize;
                    List<Course> limitCourses = Db.Courses.Skip(offset).Take(pagesize).ToList();
                    return limitCourses;
                }
            }

            return courses ?? null;          
        }

        // Get course by id
        public Course GetById(int id)
        {
            Course course = Db.Courses.Where(course => course.Id == id).SingleOrDefault();

            // check for null
            if (course != null && id > 0)
                return course;

            return null;
        }

        // GET course by name
        public Course GetByName(string name)
        {
            // Get course by using the name of the course as query parameter
            Course course = Db.Courses.Where(course => course.Name == name).SingleOrDefault();

            // check for null
            if (course != null && !string.IsNullOrEmpty(name))
                return course;

            return null;
        }

        // Patch Course by getting course with id and then update course name
        public bool UpdateNameOfCourse(string name, int id)
        {
            try
            {
                // Get Course by id
                Course updatedCourse = Db.Courses.FirstOrDefault(s => s.Id == id);

                // check for null
                if (updatedCourse == null)
                    return false;

                // update course name, update database and save changes
                updatedCourse.Name = name;
                Db.Courses.Update(updatedCourse);
                Db.SaveChanges();

                return true;
            }
            catch { return false; }
        }
    }
}