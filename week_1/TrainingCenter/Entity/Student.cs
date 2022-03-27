using System;
using System.Collections.Generic;
using System.Text;
using TrainingCenter.Service;

namespace TrainingCenter.Entity
{
    public class Student 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Lesson> Lessons;
        public List<ICourseService> Courses;

        public Student()
        {
            Lessons = new List<Lesson>();
            Courses = new List<ICourseService>();
        }
    }
}
