using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication53.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Period { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}