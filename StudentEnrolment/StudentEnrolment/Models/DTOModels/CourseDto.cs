using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.EntityModels;

namespace StudentEnrolment.Models.DTOModels
{
    public class CourseDto : Curriculum
    {
        public bool IsPartFunded { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }

        public CourseDto(
            string id, 
            string name, 
            string description, 
            bool isPartFunded, 
            ICollection<Student> students, 
            ICollection<Subject> subjects
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