using StudentEnrolment.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace StudentEnrolment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = JsonSerializer.Deserialize<List<Course>>(System.IO.File.ReadAllText("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/course.json"), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            List<Student> students = JsonSerializer.Deserialize<List<Student>>(System.IO.File.ReadAllText("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/student.json"), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            List<Subject> subjects = JsonSerializer.Deserialize<List<Subject>>(System.IO.File.ReadAllText("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/subject.json"), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            courses[1].CourseSubject = 
        }
    }
}
