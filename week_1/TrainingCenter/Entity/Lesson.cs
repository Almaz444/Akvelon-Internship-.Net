using System;
using System.Collections.Generic;
using System.Text;
using TrainingCenter.Service;
using static TrainingCenter.Enums.Enums;

namespace TrainingCenter.Entity
{
    public class Lesson: ILessonService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICourseService Course { get; set; }
        public List<Student> Students;

        public Lesson()
        {
            Students = new List<Student>();
        }
    }
}
