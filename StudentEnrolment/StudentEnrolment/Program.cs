using StudentEnrolment.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace StudentEnrolment
{
    class Program
    {
        static public List<T> DeserializeToList<T>(string filePath)
        {
            var file = System.IO.File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(file, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        static void Main(string[] args)
        {
            List<Course> courses = DeserializeToList<Course>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/course.json");
            List<Student> students = DeserializeToList<Student>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/student.json");
            List<Subject> subjects = DeserializeToList<Subject>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/subject.json");

            courses[0].CourseSubject = subjects.GetRange(0, 4);
            courses[1].CourseSubject = subjects.GetRange(4, 3);
            courses[2].CourseSubject = subjects.GetRange(7, 3);

            courses[0].CourseMembership = students.GetRange(0, 5);
            courses[1].CourseMembership = students.GetRange(5, 5);
            courses[2].CourseMembership = students.GetRange(10, 5);

        }
    }
}
