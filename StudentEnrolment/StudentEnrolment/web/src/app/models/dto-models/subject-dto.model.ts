import { CourseSubjectDto } from "./course-subject-dto.model";

export class SubjectDto {
    public id: string | null;
    public name: string;
    public description: string;
    public courses: CourseSubjectDto[] | null;

    constructor(
        id: string | null, 
        name: string, 
        description: string,
        courses: CourseSubjectDto[] | null
    )
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.courses = courses;
    }
}
