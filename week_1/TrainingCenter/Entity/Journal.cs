using System;
using System.Collections.Generic;
using System.Text;
using TrainingCenter.Service;
using static TrainingCenter.Enums.Enums;

namespace TrainingCenter.Entity
{
    public class Journal
    {
        public int Id { get; set; }
        public ILessonService Lesson { get; set; }
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public LessonMark? Mark { get; set; }
      
    }
}
