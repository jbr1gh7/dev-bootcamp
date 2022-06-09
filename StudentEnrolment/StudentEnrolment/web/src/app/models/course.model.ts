import { CourseStudentDto } from "./course-student-dto.model";
import { CourseSubjectDto } from "./course-subject-dto.model";

export class Course {
    public id: string | null;
    public name: string;
    public description: string;
    public isPartFunded: boolean;
    public courseStudent: CourseStudentDto[] | null;
    public courseSubject: CourseSubjectDto[] | null;

    constructor(
        id: string, 
        name: string, 
        description: string, 
        isPartFunded: boolean,
        courseStudent: CourseStudentDto[] | null,
        courseSubject: CourseSubjectDto[] | null
    )
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.isPartFunded = isPartFunded;
        this.courseStudent = courseStudent;
        this.courseSubject = courseSubject;
    }
}
