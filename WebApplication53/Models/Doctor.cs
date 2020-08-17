using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication53.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorCity { get; set; }
        public virtual ICollection<College> DoctorColleges { get; set; }
    }
}