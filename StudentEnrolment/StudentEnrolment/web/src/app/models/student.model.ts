import { IdBase } from "./id-base.model";

export class Student extends IdBase{
    public FirstName: string;
    public LastName: string;

    constructor(
        id: string,
        firstName: string,
        lastName: string
    ) {
        super(id);
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}
