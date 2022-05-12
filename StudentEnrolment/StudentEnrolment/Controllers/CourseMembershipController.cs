using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Data;
using StudentEnrolment.Models;

namespace StudentEnrolment.Controllers
{
    public class CourseMembershipController : Controller
    {
        private readonly EnrolmentDbContext _db;
        public CourseMembershipController(EnrolmentDbContext db)
        {
            _db = db;
        }

        [HttpGet("CourseMembership/List")]
        public List<CourseMembership> List()
        {
            List<CourseMembership> itemList = _db.CourseMembership.ToList();
            return itemList;
        }

        [HttpPost("CourseMembership/Create")]
        private IActionResult Create([FromBody] List<CourseMembership> courseMemberships)
        {
            try
            {
                for (int i = 0; i < courseMemberships.Count; i++)
                {
                    _db.CourseMembership.Add(courseMemberships[i]);
                    _db.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("CourseMembership/Delete/Student")]
        private IActionResult DeleteByStudent(Student student)
        {
            List<CourseMembership> associations = _db.CourseMembership.Where(x => x.StudentId == student.Id).ToList();
            return Delete(associations);

        }

        [HttpPost("CourseMembership/Delete/Course")]
        private IActionResult DeleteByCourse(Course course)
        {
            List<CourseMembership> associations = _db.CourseMembership.Where(x => x.CourseId == course.Id).ToList();
            return Delete(associations);
        }

        private IActionResult Delete(List<CourseMembership> associations)
        {
            if (associations != null)
            {
                try
                {
                    for (int i = 0; i < associations.Count; i++)
                    {
                        _db.CourseMembership.Remove(associations[i]);
                        _db.SaveChanges();
                    }
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
