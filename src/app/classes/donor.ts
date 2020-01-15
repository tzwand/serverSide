import { person } from "./person";
import { book } from "./book";

export class donor extends person
{
    public donorName:string
    public reqPurpose:string
    public BookId:number
    public Book:book
    public sosRequests:boolean
    public time:string
    public reqStartDate:Date
    public reqEndDate:Date
    public sosDate:Date
    public payment:number
    public sosPayment:number
    public occuptionDesc:string
    public gender:string

    constructor(
        public donorEmail:string,
        public password:string,public name:string){
           super(donorEmail,password,name);  
        this.sosRequests=false;
        this.reqStartDate=new Date(Date.now());
    }  
}


 

