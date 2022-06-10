import { Subject } from "./subject.model";
import { Course } from "./course.model";

export class CourseSubject {
    public courseId: string;
    public course: Course;

    public subjectId: string;
    public subject: Subject;

    constructor(
        courseId: string,
        course: Course,
        subjectId: string,
        subject: Subject
    )
    {
        this.courseId = courseId;
        this.course = course;
        this.subjectId = subjectId;
        this.subject = subject;
    }
}
