export class CourseStudentDto {
    public courseId: string | null;
    public studentId: string | null;

    constructor(
        courseId: string | null,
        studentId: string | null,
    )
    {
        this.courseId = courseId;
        this.studentId = studentId;
    }
}
