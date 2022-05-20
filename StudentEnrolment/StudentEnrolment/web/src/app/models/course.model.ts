import { Curriculum } from "./curriculum.model";

export class Course extends Curriculum {
    public isPartFunded: boolean;

    constructor(
        id: string, 
        name: string, 
        description: string, 
        isPartFunded: boolean
    )
    {
        super(id, name, description);
        this.isPartFunded = isPartFunded
    }
}
