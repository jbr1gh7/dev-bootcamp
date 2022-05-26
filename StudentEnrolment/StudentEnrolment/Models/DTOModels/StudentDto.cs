using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrolment.Models.DTOModels
{
    public class StudentDto : IdBase
    {
        [Column(TypeName = "varchar(40)")]
        [Required(ErrorMessage = "FirstName field is required.")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(70)")]
        [Required(ErrorMessage = "LastName field is required.")]
        public string LastName { get; set; }
        public ICollection<Course>? Courses { get; set; }

        public StudentDto(
            string id, 
            string firstName, 
            string lastName, 
            ICollection<Course>? courses
        )
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Courses = courses;
        }
    }
}
