import { IdBase } from "./id-base.model";

export class Student extends IdBase{
    public firstName: string;
    public lastName: string;

    constructor(
        id: string,
        firstName: string,
        lastName: string
    ) {
        super(id);
        this.firstName = firstName;
        this.lastName = lastName;
    }
}
