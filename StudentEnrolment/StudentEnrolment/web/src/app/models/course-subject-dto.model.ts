export class CourseSubjectDto {
    public courseId: string;
    public subjectId: string;

    constructor(
        courseId: string,
        subjectId: string,
    )
    {
        this.courseId = courseId;
        this.subjectId = subjectId;
    }
}
