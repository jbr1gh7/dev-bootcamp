import { CourseStudent } from "./course-student.model";
import { IdBase } from "./id-base.model";

export class Student extends IdBase{
    public firstName: string;
    public lastName: string;
    public courseStudent: CourseStudent[];

    constructor(
        id: string,
        firstName: string,
        lastName: string,
        courseStudent: CourseStudent[]
    ) {
        super(id);
        this.firstName = firstName;
        this.lastName = lastName;
        this.courseStudent = courseStudent;
    }
}
