using System;
using System.Collections.Generic;
using TrainingCenter.Entity;
using TrainingCenter.Service;
using static TrainingCenter.Enums.Enums;

namespace TrainingCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher();
            Course course = new Course {Id =1,Title="Biology", Teacher = teacher };
            Lesson firstLesson = new Lesson();
            ILessonService secoundLesson = new Lesson();
            List<Journal> journals = new List<Journal>();
            List<Student> students = new List<Student>();
       
            Student student = new Student { FirstName = "Luis", LastName ="Arteta", };
            Student student1 = new Student { Id = 1,FirstName = "Mike", LastName ="Haag"};
            student.Lessons.Add(firstLesson);

            students.Add(student);
            students.Add(student1);
            course.Students.Add(student1);
            course.Lessons.Add(firstLesson);
            Journal record1 = new Journal { Id = 1, Date = DateTime.Now, Lesson = firstLesson, Student = student1, Mark = LessonMark.Bad };
            Journal record2 = new Journal { Id = 2, Date = DateTime.Now, Lesson = secoundLesson, Student = student1, Mark = LessonMark.Excellent };

            int[] marks = new int[] { (int)record1.Mark, (int)record2.Mark };

            for (int i = 0; i < 2; i++)
            {
                teacher.PutMark(ref journals, students[i], firstLesson, LessonMark.Good);
            }
            FinalMark finalMark = new FinalMark();
            finalMark.Id = 1;
            finalMark.Course = course;
            finalMark.FinalMarks = course.CalculateAverage(marks, marks.Length);

            
        }
    }
}
