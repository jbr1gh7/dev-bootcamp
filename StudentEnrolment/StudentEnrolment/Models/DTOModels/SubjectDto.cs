using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.EntityModels;

namespace StudentEnrolment.Models.DTOModels
{
    public class SubjectDto : Curriculum
    {
        public IList<CourseSubject>? Courses { get; set; }

        public SubjectDto(
            string id, 
            string name, 
            string description,
            IList<CourseSubject>? courses
        )
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Courses = courses;
        }
    }
}
