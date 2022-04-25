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

            courses[0].CourseSubject = subjects.GetRange(0, 4);
            courses[1].CourseSubject = subjects.GetRange(4, 3);
            courses[2].CourseSubject = subjects.GetRange(7, 3);

            courses[0].CourseMembership = students.GetRange(0, 5);
            courses[1].CourseMembership = students.GetRange(5, 5);
            courses[2].CourseMembership = students.GetRange(10, 5);

            for (int i = 0; i < courses[2].CourseMembership.Count; i++)
            {
                Console.WriteLine(courses[2].CourseMembership[i].FirstName);
            }
        }
    }
}
