using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Data;
using StudentEnrolment.Models;
using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.DTOModels;
using StudentEnrolment.Models.EntityModels;

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
            List<Student> itemList = _db.Student
                                    .Include(c => c.CourseStudent)
                                    .ThenInclude(cs => cs.Course)
                                    .ToList();
            return itemList;
        }

        [HttpPost("Student/Create")]
        public IActionResult Create([FromBody] StudentDto studentDto)
        {
            Student student = new Student(
                studentDto.Id,
                studentDto.FirstName,
                studentDto.LastName
            );

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
