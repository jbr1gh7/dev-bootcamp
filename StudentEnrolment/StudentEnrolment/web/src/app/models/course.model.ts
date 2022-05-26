import { CourseStudent } from "./course-student.model";
import { CourseSubject } from "./course-subject.model";
import { Curriculum } from "./curriculum.model";

export class Course extends Curriculum {
    public isPartFunded: boolean;
    public courseStudent: CourseStudent[];
    public courseSubject: CourseSubject[];

    constructor(
        id: string, 
        name: string, 
        description: string, 
        isPartFunded: boolean,
        courseStudent: CourseStudent[],
        courseSubject: CourseSubject[]
    )
    {
        super(id, name, description);
        this.isPartFunded = isPartFunded;
        this.courseStudent = courseStudent;
        this.courseSubject = courseSubject;
    }
}
