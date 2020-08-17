using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication53.Models
{
    public class College
    {
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public virtual ICollection<Doctor> CollegeDoctors { get; set; }
    }
}