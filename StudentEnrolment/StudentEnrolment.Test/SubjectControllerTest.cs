using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Controllers;
using StudentEnrolment.Data;
using StudentEnrolment.Models;
using StudentEnrolment.Models.DTOModels;
using StudentEnrolment.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentEnrolment.Test
{
    public class SubjectControllerTest
    {
        private static Setup _setup = new Setup();
        private EnrolmentDbContext _db = _setup.Context();

        [Fact]
        public void Create_Subject()
        {
            // Arrange
            SubjectController subjectController = new SubjectController(_db);
            SubjectDto newSubject = new SubjectDto(null, "Colour theory", "Colours and such.", new List<CourseSubject>());

            // Act
            IActionResult createResponse = subjectController.Create(newSubject);

            // Assert
            var result = Assert.IsType<OkResult>(createResponse);
            Assert.Equal(200, result.StatusCode);

            Subject insertedSubject = _db.Subject.FirstOrDefault(s =>
                s.Name == newSubject.Name &&
                s.Description == newSubject.Description
            );

            Assert.NotNull(insertedSubject);

            _db.Subject.Remove(insertedSubject);
            _db.SaveChanges();
        }

        [Fact]
        public void Delete_Subject()
        {
            // Arrange
            SubjectController subjectController = new SubjectController(_db);

            System.Guid guid1 = Guid.NewGuid();

            Subject newSubject1 = new Subject(
                guid1.ToString(),
                "Drawing",
                "Drawing and stuff."
            );

            System.Guid guid2 = Guid.NewGuid();

            Subject newSubject2 = new Subject(
                guid2.ToString(),
                "Painting",
                "Painting and stuff."
            );

            _db.Subject.AddRange(newSubject1, newSubject2);
            _db.SaveChanges();

            List<IdBaseDto> ids = new List<IdBaseDto>();

            ids.Add(new IdBaseDto(guid1.ToString()));
            ids.Add(new IdBaseDto(guid2.ToString()));

            // Act
            IActionResult createResponse = subjectController.Delete(ids);

            // Assert
            var result = Assert.IsType<OkResult>(createResponse);
            Assert.Equal(200, result.StatusCode);

            Subject deletedSubject1 = _db.Subject.FirstOrDefault(s =>
                s.Id == guid1.ToString()
            );

            Subject deletedSubject2 = _db.Subject.FirstOrDefault(s =>
                s.Id == guid2.ToString()
            );

            Assert.Null(deletedSubject1);
            Assert.Null(deletedSubject2);
        }
    }
}

