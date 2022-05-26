using StudentEnrolment.Models.BaseClasses;

namespace StudentEnrolment.Models.EntityModels
{
    public class Subject : Curriculum
    {
        public virtual IList<CourseSubject> CourseSubject { get; set; }

        public Subject(
            string id, 
            string name, 
            string description
        )
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
