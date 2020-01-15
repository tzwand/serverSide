import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from 'selenium-webdriver/http';
import { RequestService } from '../../../services/request/request.service';
import { Time } from '../../../classes/Time';

@Component({
  selector: 'app-time',
  templateUrl: './time.component.html',
  styleUrls: ['./time.component.css']
})
export class TimeComponent implements OnInit {
from: Date;
until: Date;
times;
chosenTime
  constructor( private route: ActivatedRoute,
    private router: Router,
    private service:RequestService ) { }

  ngOnInit() {
    this.from=new Date(Date.now());
    this.until=new Date(Date.now());
    this.getTimes();
  }
  getTimes()
  {
      this.times = this.service.getTimes()//ניגש לפונקציה שלוקחת נתונים מהסרבר רק במידה שזוהי הפניה הראשונה, אחרת מחזיר את הנתונים שכבר יש לו .
  }
next(){
  this.router.navigate(['/group']);
}
}
