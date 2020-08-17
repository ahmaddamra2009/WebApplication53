using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication53.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Xxx { get; set; }
        public string Salary { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}