using StudentEnrolment.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment.Models
{
    public class Student : IdInterface
    {
        [Column(TypeName = "varchar(36)")]
        [Required(ErrorMessage = "Id field is required.")]
        public string Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        [Required(ErrorMessage = "FirstName field is required.")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(70)")]
        [Required(ErrorMessage = "LastName field is required.")]
        public string LastName { get; set; }

        public Student(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
