import { IdBase } from "./id-base.model";

export class CourseSubject extends IdBase {
    public courseId: string;
    public subjectId: string;

    constructor(
        id: string,
        courseId: string,
        subjectId: string
    )
    {
        super(id);
        this.courseId = courseId;
        this.subjectId = subjectId;
    }
}
