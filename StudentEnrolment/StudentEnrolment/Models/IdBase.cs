using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrolment.Models
{
    public class IdBase
    {
        [Column(TypeName = "varchar(36)")]
        [Required(ErrorMessage = "Id field is required.")]
        public string Id { get; set; }
    }
}
