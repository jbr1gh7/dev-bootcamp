using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Data;
using StudentEnrolment.Interfaces;
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
        static dynamic data;
        private static EnrolmentDbContext _db = new EnrolmentDbContext();

        /*
        static List<T> DeserializeToList<T>(string filePath)
        {
            var file = System.IO.File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(file, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        static void LoadDataInProgram()
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

            data = new ExpandoObject();

            data.Courses = courses;
            data.Students = students;
            data.Subjects = subjects;
        }
        */

        static string GenerateGuid()
        {
           return Guid.NewGuid().ToString();
        }

        static void ListStudents() 
        {
            List<Student> itemList = _db.Student.ToList();
            for (int i = 0; i < itemList.Count; i++) 
            { 
                Console.WriteLine("\n" + i.ToString() + ". " + itemList[i].FirstName + " " + itemList[i].LastName); 
            }
        }

        static void ListCurriculum<T>(List<T> curricula)
        where T : Curriculum
        {
            for (int i = 0; i < curricula.Count; i++)
            {
                Console.WriteLine("\n" + i.ToString() + ". " + curricula[i].Name + ":\n" + curricula[i].Description + "\n");
            }
        }

        static void ListCourses()
        {
            List<Course> itemList = _db.Course.ToList();
            ListCurriculum(itemList);
        }

        static void ListSubjects()
        {
            List<Subject> itemList = _db.Subject.ToList();
            ListCurriculum(itemList);
        }

        static string Input(string message)
        {
            bool isEmpty = true;
            string response = "";

            while (isEmpty)
            {
                Console.WriteLine("\n" + message);
                response = Console.ReadLine();

                if (response != "")
                    isEmpty = false;
                else
                    Console.WriteLine("You must input something.");
            }
            return response;
        }

        static string removeWhitespace(string input) 
        { 
            return new string(input.ToCharArray()
                        .Where(c => !Char.IsWhiteSpace(c))
                        .ToArray());
        }

        static bool ValidateChoices(string choices)
        {
            choices = new string(choices.ToCharArray()
                        .Where(c => !Char.IsWhiteSpace(c))
                        .ToArray());

            char startChar = choices[0];
            char endChar = choices[choices.Length - 1];
            bool isInvalidChars = Regex.IsMatch(choices, @"[^0-9,\s]");

            if (startChar != ',' && endChar != ',' && !isInvalidChars)
                return true;

            return false;
        }

        static void TakeChoices<T>(string message, string courseId, bool isSubject, List<T> referenceList)
            where T : IdInterface
        {
            bool isValid = false;
            while (!isValid)
            {
                string choices = Input(message);
                isValid = ValidateChoices(choices);

                if (isValid)
                {
                    string[] choiceList = choices.Split(",");
                    for (int i = 0; i < choiceList.Length; i++)
                    {
                        int referenceIndex = Int32.Parse(choiceList[i]);
                        if (referenceIndex < referenceList.Count)
                        {
                            isValid = true;
                            if (isSubject)
                            {
                                CourseSubject courseSubject = new CourseSubject(GenerateGuid(), courseId, referenceList[referenceIndex].Id);
                                Console.WriteLine(courseSubject.Id);
                                _db.CourseSubject.Add(courseSubject);
                                _db.SaveChanges();
                            }
                            else
                            {
                                CourseMembership courseMembership = new CourseMembership(GenerateGuid(), courseId, referenceList[referenceIndex].Id);
                                Console.WriteLine(courseMembership.Id);
                                _db.CourseMembership.Add(courseMembership);
                                _db.SaveChanges();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Choice does not exist. Try again.");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bad input, try again.");
                }
            }
        }

        static void AssociateNewCourse(string message, string courseId, bool isSubject)
        {
            if (isSubject)
            {
                List<Subject> referenceList = _db.Subject.ToList();
                ListSubjects();
                TakeChoices(message, courseId, isSubject, referenceList);
            }
            else
            {
                List<Student> referenceList = _db.Student.ToList();
                ListStudents();
                TakeChoices(message, courseId, isSubject, referenceList);
            }
        }

        static void deleteStudentById(string id)
        {

            Console.WriteLine("\n" + data.Students[i].FirstName + " " + data.Students[i].LastName + " was deleted.");
            return;


            Console.WriteLine("Id unrecognised.");
        }

        static List<T> deleteCurriculumById<T>(string id, List<T> curricula)
        where T : Curriculum
        {
            for (int i = 0; i < curricula.Count; i++)
            {
                if (curricula[i].Id == id)
                {
                    Console.WriteLine("\n" + curricula[i].Name + " was deleted.");
                    curricula.RemoveAt(i);
                    return curricula;
                }
            }

            Console.WriteLine("Id unrecognised.");
            return curricula;
        }

        static void removeAssocSubject(string id)
        {
            for (int i = 0; i < data.Courses.Count; i++)
            {
                for (int j = 0; j < data.Courses[i].CourseSubject.Count; j++)
                {
                    if (data.Courses[i].CourseSubject[j].Id == id)
                    {
                        Console.WriteLine(data.Courses[i].CourseSubject[j].Name + " was also removed from the " + data.Courses[i].Name + " course.");
                        data.Courses[i].CourseSubject.RemoveAt(j);
                    }
                }
            }
        }

        static void removeAssocStudent(string id)
        {
            for (int i = 0; i < data.Courses.Count; i++)
            {
                for (int j = 0; j < data.Courses[i].CourseMembership.Count; j++)
                {
                    if (data.Courses[i].CourseMembership[j].Id == id)
                    {
                        Console.WriteLine(data.Courses[i].CourseMembership[j].FirstName + " was also removed from the " + data.Courses[i].Name + " course.");
                        data.Courses[i].CourseMembership.RemoveAt(j);
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            bool isFinished = false;
            //LoadDataInProgram();

            while (!isFinished) 
            {
                string choice = Input("Select a menu choice: \n1. List all students\n2. List all courses\n3. List all subjects\n4. Add a new student\n5. Add a new course\n6. Add a new subject\n7. Delete a student\n8. Delete a course\n9. Delete a subject\n");

                switch (choice)
                {
                    case "1":
                        ListStudents();
                        break;
                    case "2":
                        ListCourses();
                        break;
                    case "3":
                        ListSubjects();
                        break;
                    case "4":
                        string studentId = GenerateGuid();
                        string firstName = Input("Input first name: ");
                        string lastName = Input("Input last name: ");

                        Student student = new Student(studentId, firstName, lastName);
                        _db.Student.Add(student);
                        _db.SaveChanges();
                        break;
                    case "5":
                        string courseId = Guid.NewGuid().ToString();
                        bool isValid = false;
                        bool isPartFunded = false;
                        
                        string courseName = Input("Input course name: ");
                        string courseDescription = Input("Input course description: ");

                        while (!isValid) 
                        {
                            string fundChoice = Input("Is this course partly funded? (y/n): ");
                            if (fundChoice.ToLower() == "y")
                            {
                                isValid = true;
                                isPartFunded = true;
                            }
                            else if (fundChoice.ToLower() == "n")
                            {
                                isValid = true;
                                isPartFunded = false;
                            }
                            else
                                Console.WriteLine("Input 'y' for yes or 'n' for no.");
                        }

                        Course course = new Course(courseId, courseName, courseDescription, isPartFunded);
                        _db.Course.Add(course);
                        _db.SaveChanges();

                        AssociateNewCourse("Which subjects are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", courseId, true);
                        AssociateNewCourse("Which students are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", courseId, false);

                        break;
                    case "6":
                        string subjectId = Guid.NewGuid().ToString();
                        string subjectName = Input("Input subject name: ");
                        string subjectDescription = Input("Input subject description: ");

                        Subject subject = new Subject(subjectId, subjectName, subjectDescription);
                        _db.Subject.Add(subject);
                        _db.SaveChanges();
                        break;
                    case "7":
                        string studentIdToDelete = Input("Input the ID of the student to delete");
                        deleteStudentById(studentIdToDelete);
                        removeAssocStudent(studentIdToDelete);
                        break;
                    case "8":
                        string courseIdToDelete = Input("Input the ID of the course to delete");
                        data.Courses = deleteCurriculumById(courseIdToDelete, data.Courses); 
                        break;
                    case "9":
                        string subjectIdToDelete = Input("Input the ID of the subject to delete");
                        data.Subjects = deleteCurriculumById(subjectIdToDelete, data.Subjects);
                        removeAssocSubject(subjectIdToDelete);
                        break;
                    default:
                        Console.Write("Input unrecognised.");
                        break;
                }
                Console.WriteLine("\n");
            }
        }
    }
}
