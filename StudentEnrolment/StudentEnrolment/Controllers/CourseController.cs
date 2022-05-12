using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Data;
using StudentEnrolment.Models;

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
            List<Course> itemList = _db.Course.ToList();
            return itemList;
        }

        [HttpPost("Course/Create")]
        public IActionResult Create([FromBody] Course course)
        {
            try
            {
                _db.Course.Add(course);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Course/Delete")]
        public IActionResult Delete([FromBody] IdBase course)
        {
            Course foundCourse = _db.Course.FirstOrDefault(x => x.Id == course.Id);
            if (foundCourse != null)
            {
                try
                {
                    _db.Course.Remove(foundCourse);
                    _db.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            return BadRequest();
        }
    }
}
