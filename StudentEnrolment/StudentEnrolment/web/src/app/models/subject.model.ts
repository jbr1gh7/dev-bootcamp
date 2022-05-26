import { CourseSubject } from "./course-subject.model";
import { Curriculum } from "./curriculum.model";

export class Subject extends Curriculum {
    public courseSubject: CourseSubject[];

    constructor(
        id: string, 
        name: string, 
        description: string,
        courseSubject: CourseSubject[]
    )
    {
        super(id, name, description);
        this.courseSubject = courseSubject;
    }
}
