using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Data;
using StudentEnrolment.Models;
using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.DTOModels;
using StudentEnrolment.Models.EntityModels;
using System.Linq;

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
            List<Subject> itemList = _db.Subject
                                    .Include(c => c.CourseSubject)
                                    .ThenInclude(cs => cs.Course)
                                    .ToList();
            return itemList;
        }

        [HttpPost("Subject/Create")]
        public IActionResult Create([FromBody] SubjectDto subjectDto)
        {
            if (subjectDto == null)
                return BadRequest();

            Guid guid = Guid.NewGuid();

            Subject subject = new Subject(
                guid.ToString(),
                subjectDto.Name,
                subjectDto.Description
            );

            try
            {
                _db.Subject.Add(subject);

                for (var i = 0; i < subjectDto.Courses.Count; i++)
                {
                    subjectDto.Courses[i].SubjectId = guid.ToString();

                    CourseSubject courseSubject =
                        new CourseSubject(
                            subjectDto.Courses[i].CourseId,
                            subjectDto.Courses[i].SubjectId
                        );

                    _db.CourseSubject.Add(courseSubject);
                }

                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost("Subject/Delete")]
        public IActionResult Delete([FromBody] List<IdBaseDto> subjects)
        {
            if (subjects == null)
                return BadRequest("subjects is null");

            for (int i = 0; i < subjects.Count; i++)
            {
                Subject foundSubject = _db.Subject.FirstOrDefault(s => s.Id == subjects[i].Id);
                if (foundSubject != null)
                {
                    try
                    {
                        _db.Subject.Remove(foundSubject);
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
