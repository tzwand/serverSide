import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Time } from '../../classes/Time';
import { occupation } from '../../classes/occupation';
import { donor } from '../../classes/donor';
import { book } from '../../classes/book';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  times: Array<Time>
  donor: donor
  donorbook: book
  occupations: Array<occupation>
  purposes: Array<string>
  constructor(private http: HttpClient) {
    this.donorbook = new book(2, "njk", 30, "nice")
    this.donor = new donor("ששש@הדה", "123456789", "אריה כהן")
    this.donor.Book = this.donorbook
    this.donor.gender = "זכר"
    this.donor.occuptionDesc = "בחור ישיבה"
    this.donor.payment = 100
    this.donor.reqEndDate = new Date("02/09/2019")
    this.donor.reqPurpose = "להצלחת הפרויקט במהירות"
    this.donor.reqStartDate = new Date("02/09/2019")
    this.donor.sosDate = null


  }
  getTimes(): Array<Time> {
    if (this.times == null) {
      this.http.get<Array<Time>>(environment.BASIC_URL + "api/forRequest/GetTimes").subscribe(success => { this.times = success; }, error => { console.log(error); })
    }
    console.log(this.donor)
    return this.times

  }
  getOccuptions(): Observable<Array<occupation>> {
    if (this.occupations == null) {
      return this.http.get<Array<occupation>>(environment.BASIC_URL + "api/forRequest/GetOccupations");
    }
    return null;
  }
  getPurposes(): Array<string> {
    return environment.purposeList
  }
  getRegularSum(): Observable<number> {
    return this.http.get<number>(environment.BASIC_URL + "api/forRequest/getRegularSum/" + this.donor.Book.BookName)
  }
  getBooks(): Observable<Array<book>> {
    return this.http.get<Array<book>>(environment.BASIC_URL + "api/forRequest/GetBooks")

  }
  sendReq(): void {
    this.http.post<boolean>(environment.BASIC_URL + "api/forRequest/addRequest", this.donor);

  }
 
}
