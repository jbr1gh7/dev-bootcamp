import { IdBase } from "./id-base.model";

export class Curriculum extends IdBase {
    public Name: string;
    public Description: string;

    constructor(
        id: string, 
        name: string, 
        description: string
    ) {
        super(id);
        this.Name = name;
        this.Description = description;
    }
}
