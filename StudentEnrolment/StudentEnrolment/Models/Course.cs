using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment.Models
{
    class Course : Curriculum
    {
        public bool IsPartFunded { get; set; }
        public List<Subject> CourseSubject { get; set; }
        public List<Student> CourseMembership { get; set; }

        public Course(string id, string name, string description, bool isPartFunded, List<Subject> courseSubject, List<Student> courseMembership)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsPartFunded = isPartFunded;
            this.CourseSubject = courseSubject;
            this.CourseMembership = courseMembership;
        }
    }
}

