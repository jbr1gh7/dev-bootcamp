import { Course } from "./course.model";
import { Student } from "./student.model";

export class CourseStudent {
    public courseId: string;
    public course: Course;

    public studentId: string;
    public student: Student;

    constructor(
        courseId: string,
        course: Course,
        studentId: string,
        student: Student
    )
    {
        this.courseId = courseId;
        this.course = course;

        this.studentId = studentId;
        this.student = student;
    }
}
