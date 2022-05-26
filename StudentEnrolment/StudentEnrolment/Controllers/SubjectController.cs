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
            List<Subject> itemList = _db.Subject.ToList();
            return itemList;
        }

        [HttpPost("Subject/Create")]
        public IActionResult Create([FromBody] SubjectDto subjectDto)
        {
            Subject subject = new Subject(
                subjectDto.Id,
                subjectDto.Name,
                subjectDto.Description
            );

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
