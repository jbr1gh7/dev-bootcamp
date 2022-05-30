using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Data;
using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.DTOModels;
using StudentEnrolment.Models.EntityModels;

namespace StudentEnrolment.Controllers
{
    public class CourseController : Controller
    {
        private readonly EnrolmentDbContext _db;
        public CourseController(EnrolmentDbContext db)
        {
            _db = db;
        }

        [HttpGet("Course/List")]
        public List<Course> List()
        {
            List<Course> itemList = _db.Course
                                    .Include(c => c.CourseSubject)
                                    .ThenInclude(cs => cs.Subject)
                                    .Include(c => c.CourseStudent)
                                    .ThenInclude(cs => cs.Student)
                                    .ToList();
               
            return itemList;
        }

        [HttpPost("Course/Create")]
        public IActionResult Create([FromBody] CourseDto courseDto)
        {
            Course course = new Course(
                courseDto.Id,
                courseDto.Name,
                courseDto.Description,
                courseDto.IsPartFunded
            );

            try
            {
                _db.AddRange(course, courseDto.Subjects, courseDto.Students);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("Course/Delete")]
        public IActionResult Delete([FromBody] List<IdBase> courses)
        {
            if (courses == null)
                return BadRequest("subjects is null");

            for (int i = 0; i < courses.Count; i++)
            {
                Course foundCourse = _db.Course.FirstOrDefault(s => s.Id == courses[i].Id);
                if (foundCourse != null)
                {
                    try
                    {
                        _db.Course.Remove(foundCourse);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Id not found");
                }
            }
            _db.SaveChanges();
            return Ok();
        }
    }
}
