import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RequestService } from '../../../services/request/request.service';
import { occupation } from '../../../classes/occupation';
import { donor } from '../../../classes/donor';


@Component({
  selector: 'app-final-screen',
  templateUrl: './final-screen.component.html',
  styleUrls: ['./final-screen.component.css']
})
export class FinalScreenComponent implements OnInit {
  occupations: occupation[]
  private donor:donor
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private req: RequestService,//נסרויס של הבקשה -כולל פונקציות שקשורות לבקשה

    // private userName: string,
    // private email: string,
    // private purpose: string,
    // private timeType: string,
    // private startDate: Date,
    // private maxPrice: number,
    // private endDate: Date,
    // private sosPrice: number,
    // private chosen: string
  ) {
    this.occupations = [];

  }
  ngOnInit() {
    this.donor = this.req.donor   //הפרטים של הבקשה בעצמה-מגיע מהתורם שבסרויס
    this.req.getOccuptions()//מקבלים ישר מהסרויס רשימת זמנים

  }
  // next() {
  //   this.req.sendReq(this.donor)
  //   this.router.navigate(['/donor/2/3']);
  // }
  next() {
    this.req.sendReq()
    this.router.navigate(['/donor/2/3']);
  }
}
