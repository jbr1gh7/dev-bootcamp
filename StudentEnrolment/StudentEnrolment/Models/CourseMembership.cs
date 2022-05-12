using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment.Models
{
    public class CourseMembership : IdBase
    {
        [Column(TypeName = "varchar(36)")]
        [Required(ErrorMessage = "CourseId field is required.")]
        public string CourseId { get; set; }
        [Column(TypeName = "varchar(36)")]
        [Required(ErrorMessage = "StudentId field is required.")]
        public string StudentId { get; set; }
        public CourseMembership(string id, string courseId, string studentId)
        {
            this.Id = id;
            this.CourseId = courseId;
            this.StudentId = studentId;
        }
    }
}
