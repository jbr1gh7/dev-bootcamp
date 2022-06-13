using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrolment.Models.BaseClasses
{
    public class Curriculum : IdBase
    {
        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
