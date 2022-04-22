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
    }
}

