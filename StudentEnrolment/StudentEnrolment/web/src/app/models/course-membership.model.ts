import { IdBase } from "./id-base.model";

export class CourseMembership extends IdBase {
    public CourseId: string;
    public StudentId: string;

    constructor(
        id: string,
        courseId: string,
        studentId: string
    )
    {
        super(id);
        this.CourseId = courseId;
        this.StudentId = studentId;
    }
}
