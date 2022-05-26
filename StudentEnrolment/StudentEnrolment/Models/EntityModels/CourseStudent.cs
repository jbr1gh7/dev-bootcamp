using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment.Models
{
    [Keyless]
    public class CourseStudent
    {
        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
