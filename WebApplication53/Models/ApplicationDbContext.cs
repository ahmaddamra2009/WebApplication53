using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication53.Models
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext():base("name=constr")
        {

        }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(v=>v.DoctorColleges)
                .WithMany(p=>p.CollegeDoctors)
                .Map(
            m=>
                {
                m.MapLeftKey("DoctorId");
                m.MapRightKey("CollegeId");
                m.ToTable("DoctorColleges");
            });
        //   base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public System.Data.Entity.DbSet<WebApplication53.Models.Department> Departments { get; set; }

        public DbSet<DoctorColleges> DoctorColleges { get; set; }
    }
}