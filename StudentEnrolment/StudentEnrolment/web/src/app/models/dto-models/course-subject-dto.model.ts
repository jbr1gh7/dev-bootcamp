export class CourseSubjectDto {
    public courseId: string | null;
    public subjectId: string | null;

    constructor(
        courseId: string | null,
        subjectId: string | null,
    )
    {
        this.courseId = courseId;
        this.subjectId = subjectId;
    }
}
