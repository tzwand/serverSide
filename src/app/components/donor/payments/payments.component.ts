import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RequestService } from '../../../services/request/request.service';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent implements OnInit {
 
sum:number;
// sosTime:Date;
// sosSum:number=0;
// sos: boolean;
  constructor( private route: ActivatedRoute,
               private router: Router,
               private req:RequestService) { }

  ngOnInit() {
  //ניגש לסרויס כדי לקבל את הסכום המקובל
this.req.getRegularSum().subscribe(success=>{this.sum=success },err=>{console.error(err) });

//  this.sosTime= null
// this.sosSum=0;
// this.sos= false;
  }
 

next(){
  this.router.navigate(['/time']);
}
}
