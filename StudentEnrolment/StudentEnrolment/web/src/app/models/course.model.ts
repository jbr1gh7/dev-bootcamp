import { Curriculum } from "./curriculum.model";

export class Course extends Curriculum {
    public IsPartFunded: boolean;

    constructor(
        id: string, 
        name: string, 
        description: string, 
        isPartFunded: boolean
    )
    {
        super(id, name, description);
        this.IsPartFunded = isPartFunded
    }
}
