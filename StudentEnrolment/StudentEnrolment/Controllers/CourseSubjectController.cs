using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Data;
using StudentEnrolment.Models;

namespace StudentEnrolment.Controllers
{
    public class CourseSubjectController : Controller
    {
        private readonly EnrolmentDbContext _db;
        public CourseSubjectController(EnrolmentDbContext db)
        {
            _db = db;
        }

        [HttpGet("CourseSubject/List")]
        public List<CourseSubject> List()
        {
            List<CourseSubject> itemList = _db.CourseSubject.ToList();
            return itemList;
        }

        [HttpPost("CourseSubject/Create")]
        private IActionResult Create([FromBody] List<CourseSubject> courseSubjects)
        {
            try
            {
                for (int i = 0; i < courseSubjects.Count; i++)
                {
                    _db.CourseSubject.Add(courseSubjects[i]);
                    _db.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("CourseSubject/Delete/Subject")]
        private IActionResult DeleteBySubject(IdBase subject)
        {
            List<CourseSubject> associations = _db.CourseSubject.Where(x => x.SubjectId == subject.Id).ToList();
            return Delete(associations);

        }

        [HttpPost("CourseSubject/Delete/Course")]
        private IActionResult DeleteByCourse(IdBase course)
        {
            List<CourseSubject> associations = _db.CourseSubject.Where(x => x.CourseId == course.Id).ToList();
            return Delete(associations);
        }

        private IActionResult Delete(List<CourseSubject> associations)
        {
            if (associations != null)
            {
                try
                {
                    for (int i = 0; i < associations.Count; i++)
                    {
                        _db.CourseSubject.Remove(associations[i]);
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
