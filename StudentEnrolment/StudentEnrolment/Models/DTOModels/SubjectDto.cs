using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.EntityModels;

namespace StudentEnrolment.Models.DTOModels
{
    public class SubjectDto : Curriculum
    {
        public ICollection<Course>? Courses { get; set; }

        public SubjectDto(
            string id, 
            string name, 
            string description, 
            ICollection<Course>? courses
        )
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Courses = courses;
        }
    }
}
