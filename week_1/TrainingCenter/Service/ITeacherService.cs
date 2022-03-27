using System;
using System.Collections.Generic;
using System.Text;
using TrainingCenter.Entity;
using static TrainingCenter.Enums.Enums;

namespace TrainingCenter.Service
{
    public interface ITeacherService
    {
        public int PutMark(ref List<Journal> journals, Student student, ILessonService lesson, LessonMark mark);
    }
}
