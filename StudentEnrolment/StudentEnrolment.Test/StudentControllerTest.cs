using Microsoft.AspNetCore.Mvc;
using StudentEnrolment.Controllers;
using StudentEnrolment.Data;
using StudentEnrolment.Models;
using StudentEnrolment.Models.BaseClasses;
using StudentEnrolment.Models.DTOModels;
using StudentEnrolment.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StudentEnrolment.Test
{
    public class StudentControllerTest
    {
        private static Setup _setup = new Setup();
        private EnrolmentDbContext _db = _setup.Context();

        [Fact]
        public void Create_Student()
        {
            // Arrange
            StudentController studentController = new StudentController(_db);
            StudentDto newStudent = new StudentDto(null, "Jacob", "Bright", new List<CourseStudent>());

            // Act
            IActionResult createResponse = studentController.Create(newStudent);

            // Assert
            var result = Assert.IsType<OkResult>(createResponse);
            Assert.Equal(200, result.StatusCode);

            Student insertedStudent = _db.Student.FirstOrDefault(s =>
                s.FirstName == newStudent.FirstName &&
                s.LastName == newStudent.LastName
            );

            Assert.NotNull(insertedStudent);

            _db.Student.Remove(insertedStudent);
            _db.SaveChanges();
        }

        [Fact]
        public void Delete_Student()
        {
            // Arrange
            StudentController studentController = new StudentController(_db);

            System.Guid guid1 = Guid.NewGuid();

            Student newStudent1 = new Student(
                guid1.ToString(),
                "Tony",
                "Baloney"
            );

            System.Guid guid2 = Guid.NewGuid();

            Student newStudent2 = new Student(
                guid2.ToString(),
                "Alfred",
                "Bean"
            );

            _db.AddRange(newStudent1, newStudent2);
            _db.SaveChanges();

            List<IdBaseDto> ids = new List<IdBaseDto>();

            ids.Add(new IdBaseDto(guid1.ToString()));
            ids.Add(new IdBaseDto(guid2.ToString()));

            // Act
            IActionResult createResponse = studentController.Delete(ids);

            // Assert
            var result = Assert.IsType<OkResult>(createResponse);
            Assert.Equal(200, result.StatusCode);

            Student deletedStudent1 = _db.Student.FirstOrDefault(s =>
                s.Id == guid1.ToString()
            );

            Student deletedStudent2 = _db.Student.FirstOrDefault(s =>
                s.Id == guid2.ToString()
            );

            Assert.Null(deletedStudent1);
            Assert.Null(deletedStudent2);
        }
    }
}