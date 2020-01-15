import { Injectable } from '@angular/core';
import {person } from '../../classes/person';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { learner } from '../../classes/learner';
import { environment } from '../../../environments/environment';
import { donor } from '../../classes/donor';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  currentUser;
  currentDonor;
  currentLearner;

  constructor(private http: HttpClient) { }

  getAllPeople(): Observable<Array<learner>> {
    return this.http.get<Array<learner>>(environment.BASIC_URL + "getAll");
  }
  getLearner(email: string,password:string): Observable<learner> {
    return this.http.post<learner>(environment.BASIC_URL + "api/user/findLearnerByEmailAndPassword" ,[email,password]);
  }
  getDonor(email: string,password:string): Observable<donor> {
    return this.http.post<donor> (environment.BASIC_URL + "api/user/findDonorByEmailAndPassword" ,[email,password]);
  }
  addLearner(name: string,email:string): Observable<learner> {
    return this.http.post<learner>(environment.BASIC_URL + "api/user/addLearner",[name,email]);
  }
  addDonor(name: string,email:string): Observable<Array<person>> {
    return this.http.post<Array<person>>(environment.BASIC_URL + "api/user/addDonor", [name,email]);
  }
  resetPassword(type:string,email:string, startMonth:string,startYear:string): Observable<Array<person>> {
    return this.http.post<Array<person>>(environment.BASIC_URL + "api/user/resetPassword", [type,email,startMonth,startYear]);
  }

  deleteperson(p: person): Observable<Array<person>> {
    return this.http.delete<Array<person>>(environment.BASIC_URL + "Delete/" + p);
  }

  updateperson(p: person) {
    return this.http.put<Array<person>>(environment.BASIC_URL + "Put", p);
  }

}
