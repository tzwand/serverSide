import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private router: Router, private service: UserService) { }
email;
startMonth
startYear
  ngOnInit() {

  }
  resetPassword(){

    this.service.resetPassword( sessionStorage.getItem('userEmail'),sessionStorage.getItem('userType'),this.startMonth,this.startYear )
      .subscribe(success => {
        alert(" הסיסמא נשלחה בהצלחה");
        // this.router.navigate(["/login/"+sessionStorage.getItem('userType')])
         this.router.navigate(["/login/"+0])
        // this.router.navigate(['/login/']);
      }
        , error => { console.log("It's a problem - " + error.massage) })
      }
}
