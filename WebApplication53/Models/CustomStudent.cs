using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    [MetadataType(typeof(CustomStudent))]
    public partial class Student
    {
        public class CustomStudent
        {
            public int StudentId { get; set; }
            [Required(ErrorMessage ="Enter Student name")]
            public string StudentName { get; set; }
            public string City { get; set; }
            [Required(ErrorMessage = "Choose Student Image")]
            public string StudentImg { get; set; }
        }
    }

    [MetadataType(typeof(CustomCourses))]
    public partial class Course
    {
        public class CustomCourses
        {
            public int CourseId { get; set; }
            [Required(ErrorMessage = "Course name")]
            public string CourseName { get; set; }
            [Required(ErrorMessage = "Course Period")] 
            public string Period { get; set; }
        


        }
    }



}