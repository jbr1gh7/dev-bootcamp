import { Course } from "./course.model";
import { IdBase } from "./id-base.model";
import { Student } from "./student.model";

export class CourseStudent extends IdBase {
    public courseId: string;
    public course: Course;

    public studentId: string;
    public student: Student;

    constructor(
        id: string,
        courseId: string,
        course: Course,
        studentId: string,
        student: Student
    )
    {
        super(id);
        this.courseId = courseId;
        this.course = course;

        this.studentId = studentId;
        this.student = student;
    }
}
