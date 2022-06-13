using StudentEnrolment.Models.BaseClasses;

namespace StudentEnrolment.Models.EntityModels
{
    public class Course : Curriculum
    {
        public bool IsPartFunded { get; set; }
        public virtual IList<CourseStudent> CourseStudent { get; set; }
        public virtual IList<CourseSubject> CourseSubject { get; set; }

        public Course(
            string id,
            string name,
            string description,
            bool isPartFunded
        )
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsPartFunded = isPartFunded;


        }
    }
}

