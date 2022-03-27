using System;
using System.Collections.Generic;
using System.Text;
using TrainingCenter.Service;
using static TrainingCenter.Enums.Enums;

namespace TrainingCenter.Entity
{
    public class Teacher : ITeacherService
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<ICourseService> Courses;

        public Teacher()
        {
            Courses = new List<ICourseService>();
        }

        //Put mark to the certain student for the specific lesson
        public int PutMark(ref List<Journal> journals,Student student,ILessonService lesson, LessonMark mark)
        {
            Journal journal = new Journal();
            journal.Student = student;
            journal.Lesson = lesson;
            journal.Mark = mark;
            journals.Add(journal);
            if (journals.Contains(journal))
            {
                return 1;
            }
            else 
            {
                return 0;
            }  
        }
    }
}
