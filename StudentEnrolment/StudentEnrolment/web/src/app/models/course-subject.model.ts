import { IdBase } from "./id-base.model";

export class CourseSubject extends IdBase {
    public CourseId: string;
    public SubjectId: string;

    constructor(
        id: string,
        courseId: string,
        subjectId: string
    )
    {
        super(id);
        this.CourseId = courseId;
        this.SubjectId = subjectId;
    }
}
