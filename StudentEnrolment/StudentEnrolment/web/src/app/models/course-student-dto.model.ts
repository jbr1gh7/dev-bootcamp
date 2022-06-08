export class CourseStudentDto {
    public courseId: string;
    public studentId: string | null;

    constructor(
        courseId: string,
        studentId: string | null,
    )
    {
        this.courseId = courseId;
        this.studentId = studentId;
    }
}
