using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.EntityModels;

namespace StudentEnrolment.Models.DTOModels
{
    public class CourseDto : Curriculum
    {
        public bool IsPartFunded { get; set; }
        public IList<CourseStudent>? Students { get; set; }
        public IList<CourseSubject>? Subjects { get; set; }

        public CourseDto(
            string id, 
            string name, 
            string description, 
            bool isPartFunded,
            IList<CourseStudent>? students,
            IList<CourseSubject>? subjects
        )
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsPartFunded = isPartFunded;
            this.Students = students;
            this.Subjects = subjects;
        }
    }
}