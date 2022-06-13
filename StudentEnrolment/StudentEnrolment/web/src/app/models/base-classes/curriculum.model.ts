import { IdBase } from "./id-base.model";

export class Curriculum extends IdBase {
    public name: string;
    public description: string;

    constructor(
        id: string, 
        name: string, 
        description: string
    ) {
        super(id);
        this.name = name;
        this.description = description;
    }
}
