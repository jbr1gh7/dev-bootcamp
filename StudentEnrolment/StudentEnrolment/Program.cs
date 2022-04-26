using StudentEnrolment.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace StudentEnrolment
{
    class Program
    {
        static object LoadDataInProgram()
        {
            List<Course> courses = DeserializeToList<Course>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/course.json");
            List<Student> students = DeserializeToList<Student>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/student.json");
            List<Subject> subjects = DeserializeToList<Subject>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/subject.json");

            courses[0].CourseSubject = subjects.GetRange(0, 4); //Engineering
            courses[1].CourseSubject = subjects.GetRange(4, 3); //Chemistry
            courses[2].CourseSubject = subjects.GetRange(7, 3); //Law

            courses[0].CourseMembership = students.GetRange(0, 5); //first 5
            courses[1].CourseMembership = students.GetRange(5, 5); //next 5
            courses[2].CourseMembership = students.GetRange(10, 5); //last 5

            dynamic data = new ExpandoObject();

            data.Courses = courses;
            data.Students = students;
            data.Subjects = subjects;

            return data;
        }

        static List<T> DeserializeToList<T>(string filePath)
        {
            var file = System.IO.File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(file, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        static void ListStudents(List<Student> students) 
        {
            Console.WriteLine("\n");
            for (int i = 0; i < students.Count; i++) { Console.WriteLine(i.ToString() + ". " + students[i].FirstName + " " + students[i].LastName); }
        }

        static void ListCurriculum<T>(List<T> curricula)
        where T : Curriculum
        {
            Console.WriteLine("\n");
            for (int i = 0; i < curricula.Count; i++) { Console.WriteLine(i.ToString() + ". " + curricula[i].Name + ":\n" + curricula[i].Description + "\n"); }
        }

        static string Input(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static List<T> MakeAssocFromInput<T>(string message, dynamic data, bool isSubject)
        {
            bool isValid = false;
            List<T> referenceList;
            List<T> assocList = new List<T>();

            if (isSubject)
            {
                referenceList = data.Subjects;
                ListCurriculum(data.Subjects);
            }
            else
            {
                referenceList = data.Students;
                ListStudents(data.Students);
            }

            while (!isValid)
            {
                string choices = Input(message);
                choices = new string(choices.ToCharArray()
                        .Where(c => !Char.IsWhiteSpace(c))
                        .ToArray());

                char startChar = choices[0];
                char endChar = choices[choices.Length - 1];
                bool isValidChars = Regex.IsMatch(choices, @"[^0-9,\s]");

                if (startChar != ',' && endChar != ',' && !isValidChars)
                {
                    isValid = true;
                    string[] choiceList = choices.Split(",");

                    for (int i = 0; i < choiceList.Length; i++)
                    {
                        int index = Int32.Parse(choiceList[i]);
                        assocList.Add(referenceList[index]);
                    }
                }
                else
                {
                    Console.WriteLine("Bad input, try again.");
                }
            }

            return assocList;
        }

        static void Main(string[] args)
        {
            bool isFinished = false;
            dynamic data = LoadDataInProgram();

            while (!isFinished) 
            {
                string choice = Input("Select a menu choice: \n1. List all students\n2. List all courses\n3. List all subjects\n4. Add a new student\n5. Add a new course\n6. Add a new subject\n7. Delete a student\n8. Delete a course\n9. Delete a subject");
                Console.WriteLine("\n");

                switch (choice)
                {
                    case "1":
                        ListStudents(data.Students);
                        break;
                    case "2":
                        ListCurriculum(data.Courses);
                        break;
                    case "3":
                        ListCurriculum(data.Subjects);
                        break;
                    case "4":
                        string studentId = Guid.NewGuid().ToString();
                        string firstName = Input("Input first name: ");
                        string lastName = Input("Input last name: ");

                        data.Students.Add(new Student(studentId, firstName, lastName));
                        break;
                    case "5":
                        string courseId = Guid.NewGuid().ToString();
                        string courseName = Input("Input course name: ");
                        string courseDescription = Input("Input course description: ");

                        string fundChoice = Input("Is this course partly funded? (y/n): ");
                        bool isPartFunded = fundChoice.ToLower() == "y" ? true : false;

                        List<Subject> courseSubject = MakeAssocFromInput<Subject>("Which subjects are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", data, true);

                        for (int i = 0; i < courseSubject.Count; i++)
                            Console.WriteLine(courseSubject[i].Name);

                        List<Student> courseMembership = MakeAssocFromInput<Student>("Which students are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", data, false);

                        for (int i = 0; i < courseMembership.Count; i++)
                            Console.WriteLine(courseMembership[i].FirstName);

                        data.Courses.Add(new Course(courseId, courseName, courseDescription, isPartFunded, courseSubject, courseMembership));
                        break;
                    case "6":
                        string subjectId = Guid.NewGuid().ToString();
                        string subjectName = Input("Input subject name: ");
                        string subjectDescription = Input("Input subject description: ");

                        data.Subjects.Add(new Subject(subjectName, subjectDescription, subjectId));
                        break;
                    case "7":
                        // code block
                        break;
                    case "8":
                        // code block
                        break;
                    default:
                        // code block
                        break;
                }
                Console.WriteLine("\n");
            }
        }
    }
}
