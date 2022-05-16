using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment.Models
{
    public class Course : Curriculum
    {
        public bool IsPartFunded { get; set; }

        public Course(string id, string name, string description, bool isPartFunded)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsPartFunded = isPartFunded;
        }
    }
}

