import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { offer } from '../../classes/offer';
import { learner } from '../../classes/learner';
import { matching } from 'src/app/classes/matching';

@Injectable({
  providedIn: 'root'
})
export class AddLearningService {
 l= new learner("hh@gmail.com","111111")
  // [x: string]: any;
  constructor(private http: HttpClient) { 
    sessionStorage.setItem("currentLearner","7")
  }
  getCurrentRequests(): Observable<Array<offer>> {
    return this.http.get<Array<offer>>(environment.BASIC_URL + "api/learner/getCurrentRequests")
  }
  addLearning(m:matching):Observable<string>
  {
    
    return this.http.post<string>(environment.BASIC_URL+"api/learner/addLearning",m)
  }
}
