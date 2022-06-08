import { Course } from "./course.model";
import { Student } from "./student.model";

export class CourseStudentDto {
    public courseId: string;
    public course: Course;

    public studentId: string | null;
    public student: Student | null;

    constructor(
        courseId: string,
        course: Course,
        studentId: string | null,
        student: Student | null
    )
    {
        this.courseId = courseId;
        this.course = course;

        this.studentId = studentId;
        this.student = student;
    }
}
