using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Data;
using StudentEnrolment.Models;

namespace StudentEnrolment.Controllers
{
    public class SubjectController : Controller
    {
        private readonly EnrolmentDbContext _db;
        public SubjectController(EnrolmentDbContext db)
        {
            _db = db;
        }

        [HttpGet("Subject/List")]
        public List<Subject> List()
        {
            List<Subject> itemList = _db.Subject.ToList();
            return itemList;
        }

        [HttpPost("Subject/Create")]
        public IActionResult Create([FromBody] Subject subject)
        {
            try
            {
                _db.Subject.Add(subject);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Subject/Delete")]
        public IActionResult Delete([FromBody] IdBase subject)
        {
            Subject foundSubject = _db.Subject.FirstOrDefault(x => x.Id == subject.Id);
            if (foundSubject != null)
            {
                try
                {
                    _db.Subject.Remove(foundSubject);
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
