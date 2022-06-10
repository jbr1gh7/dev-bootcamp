import { CourseStudentDto } from "./course-student-dto.model";

export class StudentDto {
    public id: string | null;
    public firstName: string;
    public lastName: string;
    public courses: CourseStudentDto[] | null;

    constructor(
        id: string | null,
        firstName: string,
        lastName: string,
        courses: CourseStudentDto[] | null
    ) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.courses = courses;
    }
}