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
    public class CourseSubject
    {
        [Column(TypeName = "varchar(36)")]
        [Required(ErrorMessage = "Id field is required.")]
        public string Id { get; set; }
        [ForeignKey("Course")]
        [Column(TypeName = "varchar(36)")]
        [Required(ErrorMessage = "CourseId field is required.")]
        public string CourseId { get; set; }
        [ForeignKey("Subject")]
        [Column(TypeName = "varchar(36)")]
        [Required(ErrorMessage = "SubjectId field is required.")]
        public string SubjectId { get; set; }
        public CourseSubject(string id, string courseId, string subjectId)
        {
            this.Id = id;
            this.CourseId = courseId;
            this.SubjectId = subjectId;
        }
    }
}
