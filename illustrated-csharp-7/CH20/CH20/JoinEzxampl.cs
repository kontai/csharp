using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH20
{
    internal class JoinEzxampl
    {
        public class Student
        {
            public int StID;
            public string LastName;
        }

        public class CourseStudent
        {
            public string CourseName;
            public int StID;
        }

        private static Student[] students = new Student[]
        {
            new Student { StID = 1, LastName = "Carson" },
            new Student { StID = 2, LastName = "Klassen" },
            new Student { StID = 3, LastName = "Fleming" },
        };

        static CourseStudent[] studentsInCourse = new CourseStudent[]
        {
            new CourseStudent { CourseName = "Art", StID = 1 },
            new CourseStudent { CourseName = "Art", StID = 2 },
            new CourseStudent { CourseName = "History", StID = 1 },
            new CourseStudent { CourseName = "History", StID = 3 },
            new CourseStudent { CourseName = "Physics", StID = 3 },
        };
        static void Main(string[] args)
        {
            var query = from s in students
                        join c in studentsInCourse on s.StID equals c.StID
                        where c.CourseName == "History"
                        select s.LastName;

            foreach (var q in query)
            {
                Console.WriteLine($"Student taking History: {q}");
            }
        }
    }
}