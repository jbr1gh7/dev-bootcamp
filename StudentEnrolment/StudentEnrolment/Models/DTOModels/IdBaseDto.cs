using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrolment.Models.DTOModels
{
    public class IdBaseDto
    {
        public string Id { get; set; }
        
        public IdBaseDto(string id)
        {
            this.Id = id;
        }
    }
}

