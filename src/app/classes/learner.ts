import { person } from "./person";

export class learner extends person {
    public learnerName: string;
    public gender: string;
    public occuptionName: string;
    public sosRequests: boolean;
    public startDate: Date;
    public endDate: Date;
    public groupName: string;
    public wantsToJoin: boolean;

    constructor(public learnerEmail: string,
        public password: string) {
        super(learnerEmail, password);
        this.startDate = new Date(Date.now());
        this.sosRequests = false;
    }
}

   
