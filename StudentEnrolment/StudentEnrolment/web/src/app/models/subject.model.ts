import { Curriculum } from "./curriculum.model";

export class Subject extends Curriculum {

    constructor(
        id: string, 
        name: string, 
        description: string
    )
    {
        super(id, name, description);
    }
}
