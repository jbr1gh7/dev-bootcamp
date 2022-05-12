using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment.Models
{
    public class Curriculum : IdBase
    {
        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
