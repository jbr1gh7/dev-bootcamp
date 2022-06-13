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
    public class CourseControllerTest
    {
        private static Setup _setup = new Setup();
        private EnrolmentDbContext _db = _setup.Context();

        [Fact]
        public void Create_Course()
        {
            // Arrange
            CourseController courseController = new CourseController(_db);
            CourseDto newCourse = new CourseDto(
                null, 
                "History", 
                "The past and such.", 
                false, 
                new List<CourseStudent>(), 
                new List<CourseSubject>()
            );

            // Act
            IActionResult createResponse = courseController.Create(newCourse);

            // Assert
            var result = Assert.IsType<OkResult>(createResponse);
            Assert.Equal(200, result.StatusCode);

            Course insertedCourse = _db.Course.FirstOrDefault(s =>
                s.Name == newCourse.Name &&
                s.Description == newCourse.Description &&
                s.IsPartFunded == newCourse.IsPartFunded
            );

            Assert.NotNull(insertedCourse);

            _db.Course.Remove(insertedCourse);
            _db.SaveChanges();
        }

        [Fact]
        public void Delete_Course()
        {
            // Arrange
            CourseController courseController = new CourseController(_db);

            System.Guid guid1 = Guid.NewGuid();

            Course newCourse1 = new Course(
                guid1.ToString(),
                "Chemistry",
                "Chemicals and stuff.",
                true
            );

            System.Guid guid2 = Guid.NewGuid();

            Course newCourse2 = new Course(
                guid2.ToString(),
                "Physics",
                "The universe and stuff",
                true
            );

            _db.Course.AddRange(newCourse1, newCourse2);
            _db.SaveChanges();

            List<IdBaseDto> ids = new List<IdBaseDto>();

            ids.Add(new IdBaseDto(guid1.ToString()));
            ids.Add(new IdBaseDto(guid2.ToString()));

            // Act
            IActionResult createResponse = courseController.Delete(ids);

            // Assert
            var result = Assert.IsType<OkResult>(createResponse);
            Assert.Equal(200, result.StatusCode);

            Course deletedCourse1 = _db.Course.FirstOrDefault(s =>
                s.Id == guid1.ToString()
            );

            Course deletedCourse2 = _db.Course.FirstOrDefault(s =>
                s.Id == guid2.ToString()
            );

            Assert.Null(deletedCourse1);
            Assert.Null(deletedCourse2);
        }
    }
}
