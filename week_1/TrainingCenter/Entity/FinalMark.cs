using System;
using System.Collections.Generic;
using System.Text;
using TrainingCenter.Service;

namespace TrainingCenter.Entity
{
    public class FinalMark
    {
        public int Id { get; set; }
        public ICourseService Course { get; set; }
        //results of the entire course
        public double FinalMarks { get; set;}
    }
}
