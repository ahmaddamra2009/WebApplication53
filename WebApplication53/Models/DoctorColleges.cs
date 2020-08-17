using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication53.Models
{
    public class DoctorColleges
    {
        [Key]
        [Column(Order =1)]
        public int DoctorId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CollegeId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual  College College { get; set; }
    }
}