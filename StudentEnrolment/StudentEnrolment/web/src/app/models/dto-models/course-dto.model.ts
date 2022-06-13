import { CourseStudentDto } from "./course-student-dto.model";
import { CourseSubjectDto } from "./course-subject-dto.model";

export class CourseDto {
    public id: string | null;
    public name: string;
    public description: string;
    public isPartFunded: boolean;
    public students: CourseStudentDto[] | null;
    public subjects: CourseSubjectDto[] | null;

    constructor(
        id: string | null, 
        name: string, 
        description: string, 
        isPartFunded: boolean,
        students: CourseStudentDto[] | null,
        subjects: CourseSubjectDto[] | null
    )
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.isPartFunded = isPartFunded;
        this.students = students;
        this.subjects = subjects;
    }
}
