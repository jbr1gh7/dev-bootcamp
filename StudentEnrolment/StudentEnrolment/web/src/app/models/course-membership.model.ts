import { IdBase } from "./id-base.model";

export class CourseMembership extends IdBase {
    public courseId: string;
    public studentId: string;

    constructor(
        id: string,
        courseId: string,
        studentId: string
    )
    {
        super(id);
        this.courseId = courseId;
        this.studentId = studentId;
    }
}
