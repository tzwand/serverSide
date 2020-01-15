import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private http:HttpClient) { }
sendEmail(email:string){
  this.http.post(environment.BASIC_URL+"api/email/",email);
}

}
