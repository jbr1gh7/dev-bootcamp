using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Data;
using StudentEnrolment.Interfaces;
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
        public IActionResult Delete([FromBody] Student student)
        {
            Student foundStudent = _db.Student.FirstOrDefault(x => x.Id == student.Id);
            if (foundStudent != null)
            {
                try
                {
                    RemoveAssocStudent(student.Id);
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

        private void RemoveAssocStudent(string studentId)
        {
            List<CourseMembership> associations = _db.CourseMembership.Where(x => x.StudentId == studentId).ToList();
            if (associations != null)
            {
                for (int i = 0; i < associations.Count; i++)
                {
                    _db.CourseMembership.Remove(associations[i]);
                    _db.SaveChanges();
                }

                Console.WriteLine("The student was removed from their associated courses.");
            }
        }
    }
}
