using System;
using Xunit;
using TrainingCenter;
using TrainingCenter.Entity;
using TrainingCenter.Service;
using static TrainingCenter.Enums.Enums;
using TrainingCenter.Enums;
using System.Collections.Generic;

namespace TrainingCentetTests
{
    public class UnitTest1
    {
        [Fact]
        public void PutMark_AddItemToList_ReturnOne ()
        {
            // arrange
            Teacher teacher = new Teacher();
            Student student = new Student {Id = 1, FirstName = "Luis", LastName = "Arteta" };
            ILessonService firstLesson = new Lesson();
            List<Journal> journals = new List<Journal>();

            // act
            var action = teacher.PutMark(ref journals, student, firstLesson, LessonMark.Excellent);
            int result = 1;

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void CalculateAverage_ArrayInt_ReturnDouble2()
        {
            // arrange
            Course course = new Course();
            int[] array = new int[] { 1, 1, 1, 5 };
            int length = array.Length;

            // act
            var action = course.CalculateAverage(array, length);
            int result = 2;

            // assert
            Assert.Equal(result, action);
        }

    }
}
