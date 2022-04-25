using StudentEnrolment.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace StudentEnrolment
{
    class Program
    {
        static List<T> DeserializeToList<T>(string filePath)
        {
            var file = System.IO.File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(file, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        static string Input(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static List<T> makeAssocFromInput<T>(string message, List<T> reference)
        {
            string choices = Input(message);
            string[] choiceList = choices.Split(",");

            List<T> assocList = new List<T>();

            for (int i = 0; i < choiceList.Length; i++)
            {
                int index = Int32.Parse(choiceList[i]);
                assocList.Add(reference[index]);
            }

            return assocList;
        }

        static void Main(string[] args)
        {
            bool isFinished = false;

            List<Course> courses = DeserializeToList<Course>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/course.json");
            List<Student> students = DeserializeToList<Student>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/student.json");
            List<Subject> subjects = DeserializeToList<Subject>("C:/Users/jacobbright/Documents/GitHub/dev-bootcamp/StudentEnrolment/StudentEnrolment/Test_Data/subject.json");

            courses[0].CourseSubject = subjects.GetRange(0, 4); //Engineering
            courses[1].CourseSubject = subjects.GetRange(4, 3); //Chemistry
            courses[2].CourseSubject = subjects.GetRange(7, 3); //Law

            courses[0].CourseMembership = students.GetRange(0, 5);
            courses[1].CourseMembership = students.GetRange(5, 5);
            courses[2].CourseMembership = students.GetRange(10, 5);

            while (!isFinished) 
            {
                string choice = Input("Select a menu choice: \n1. List all students\n2. List all courses\n3. List all subjects\n4. Add a new student\n5. Add a new course\n6. Add a new subject\n7. Delete a student\n8. Delete a course\n9. Delete a subject");
                Console.WriteLine("\n");

                switch (choice)
                {
                    case "1":
                        for (int i = 0; i < students.Count; i++) { Console.WriteLine(students[i].FirstName + " " + students[i].LastName); }
                        break;
                    case "2":
                        for (int i = 0; i < courses.Count; i++) { Console.WriteLine(courses[i].Name + ":\n" + courses[i].Description + "\n"); }
                        break;
                    case "3":
                        for (int i = 0; i < subjects.Count; i++) { Console.WriteLine(subjects[i].Name + ":\n" + subjects[i].Description + "\n"); }
                        break;
                    case "4":
                        string studentId = Guid.NewGuid().ToString();
                        string firstName = Input("Input first name: ");
                        string lastName = Input("Input last name: ");

                        students.Add(new Student(studentId, firstName, lastName));
                        break;
                    case "5":
                        string courseId = Guid.NewGuid().ToString();
                        string courseName = Input("Input course name: ");
                        string courseDescription = Input("Input course description: ");

                        string fundChoice = Input("Is this course partly funded? (y/n): ");
                        bool isPartFunded = fundChoice.ToLower() == "y" ? true : false;

                        List<Subject> courseSubject = makeAssocFromInput("Which subjects are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", subjects);
                        List<Student> courseMembership = makeAssocFromInput("Which students are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", students);

                        courses.Add(new Course(courseId, courseName, courseDescription, isPartFunded, courseSubject, courseMembership));
                        break;
                    case "6":
                        string subjectId = Guid.NewGuid().ToString();
                        string subjectName = Input("Input subject name: ");
                        string subjectDescription = Input("Input subject description: ");

                        subjects.Add(new Subject(subjectName, subjectDescription, subjectId));
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
