import { Subject } from "./subject.model";
import { Course } from "./course.model";
import { IdBase } from "./id-base.model";

export class CourseSubject extends IdBase {
    public courseId: string;
    public course: Course;

    public subjectId: string;
    public subject: Subject;

    constructor(
        id: string,
        courseId: string,
        course: Course,
        subjectId: string,
        subject: Subject
    )
    {
        super(id);
        this.courseId = courseId;
        this.course = course;
        this.subjectId = subjectId;
        this.subject = subject;
    }
}
