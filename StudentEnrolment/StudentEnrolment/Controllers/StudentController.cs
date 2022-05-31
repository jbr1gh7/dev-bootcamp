using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Data;
using StudentEnrolment.Models;

namespace StudentEnrolment.Controllers
{
    public class StudentController : Controller
    {
        private readonly EnrolmentDbContext _db;
        public StudentController(EnrolmentDbContext db)
        {
            _db = db;
        }

        [HttpGet("Student/List")]
        public List<Student> List()
        {
            List<Student> itemList = _db.Student.ToList();
            return itemList;
        }

        [HttpPost("Student/Create")]
        public IActionResult Create([FromBody] Student student)
        {
            try
            {
                _db.Student.Add(student);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Student/Delete")]
        public IActionResult Delete([FromBody] IdBase student)
        {
            Student foundStudent = _db.Student.FirstOrDefault(x => x.Id == student.Id);
            if (foundStudent != null)
            {
                try
                {
                    _db.Student.Remove(foundStudent);
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
