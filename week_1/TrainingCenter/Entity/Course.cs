using System;
using System.Collections.Generic;
using System.Text;
using TrainingCenter.Service;

namespace TrainingCenter.Entity
{
    public class Course : ICourseService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ITeacherService Teacher { get; set; }
        public List<ILessonService> Lessons;
        public List<Student> Students;

        public Course()
        {
            Lessons = new List<ILessonService>();
            Students = new List<Student>();
        }
        public double CalculateAverage(int[] array, int length)
        {
                int sum = 0;
                for (int i = 0; i < length; i++)
                    sum += array[i];
                return (double)sum / length; 
        }
    }
}
