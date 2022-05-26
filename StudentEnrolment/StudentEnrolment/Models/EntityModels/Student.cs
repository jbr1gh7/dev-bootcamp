using StudentEnrolment.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrolment.Models.EntityModels
{
    public class Student : IdBase
    {
        [Column(TypeName = "varchar(40)")]
        [Required(ErrorMessage = "FirstName field is required.")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(70)")]
        [Required(ErrorMessage = "LastName field is required.")]
        public string LastName { get; set; }
        public virtual IList<CourseStudent> CourseStudent { get; set; }

        public Student(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
