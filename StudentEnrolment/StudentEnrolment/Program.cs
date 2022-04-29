﻿using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Data;
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

        static async void ListStudents() 
        {
            List<Student> itemList = await _db.Student.ToListAsync();
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

        static async void ListCourses()
        {
            List<Course> itemList = await _db.Course.ToListAsync();
            ListCurriculum(itemList);
        }

        static async void ListSubjects()
        {
            List<Subject> itemList = await _db.Subject.ToListAsync();
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

        static List<T> MakeAssocFromInput<T>(string message, bool isSubject)
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
                ListStudents();
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
                    string[] choiceList = choices.Split(","); 
                    for (int i = 0; i < choiceList.Length; i++)
                    {
                        int referenceIndex = Int32.Parse(choiceList[i]);
                        if (referenceIndex < referenceList.Count)
                        {
                            isValid = true;
                            assocList.Add(referenceList[referenceIndex]);
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

            return assocList;
        }

        static void deleteStudentById(string id)
        {
            for (int i = 0; i < data.Students.Count; i++)
            {
                if (data.Students[i].Id == id)
                {
                    Console.WriteLine("\n" + data.Students[i].FirstName + " " + data.Students[i].LastName + " was deleted.");
                    data.Students.RemoveAt(i);
                    return;
                }
            }

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
                        string studentId = Guid.NewGuid().ToString();
                        string firstName = Input("Input first name: ");
                        string lastName = Input("Input last name: ");

                        data.Students.Add(new Student(studentId, firstName, lastName));
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

                        List<Subject> courseSubject = MakeAssocFromInput<Subject>("Which subjects are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", true);
                        List<Student> courseMembership = MakeAssocFromInput<Student>("Which students are associated with this course?\nSelect using integers delimited by a comma (e.g 1,3,5,7): ", false);

                        //data.Courses.Add(new Course(courseId, courseName, courseDescription, isPartFunded, courseSubject, courseMembership));
                        break;
                    case "6":
                        string subjectId = Guid.NewGuid().ToString();
                        string subjectName = Input("Input subject name: ");
                        string subjectDescription = Input("Input subject description: ");

                        data.Subjects.Add(new Subject(subjectId, subjectName, subjectDescription));
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
