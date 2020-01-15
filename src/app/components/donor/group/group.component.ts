import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RequestService } from '../../../services/request/request.service';
import { occupation } from '../../../classes/occupation';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})

export class GroupComponent implements OnInit {
  genders: string[] = ['זכר', 'נקבה', 'לא משנה'];
  constructor(private route: ActivatedRoute,
    private router: Router, private req: RequestService) { }
  selected: string;
  Occupations: occupation[];
  test:any[];
  chosenTest:any;
  viewtest: any[]
  viewOccupations: occupation[];
  //genders: string[];
  ngOnInit() {
    //אמור להגיע מהסרבר
    //this.genders = ["זכר", "נקבה", "לא משנה"];
  this.req.getOccuptions().subscribe(l=>{

  }
  )
    this.Occupations = []
    this.test= [1,2,1,2]
    this.viewtest=["","","",""]
  }
  next() {

    this.router.navigate(['/finalScreen'])
  }
  getOccupations() {
    // this.Occupations = this.req.getOccuptions()
  }
  mychange(num) {

  //   if (this.selected == "נקבה")
  //     this.viewOccupations = this.Occupations.filter(v => v.gender == "נקבה")

  //   if (this.selected == "זכר")
  //     this.viewOccupations = this.Occupations.filter(v => v.gender == "זכר")

  //   if (this.selected == "לא משנה")
  //     this.viewOccupations = this.Occupations
  // }


  alert("ok")
  if (num == 0)
      this.viewtest == this.test.filter(v => v==1 )
debugger
    if ( num ==1)
      this.viewtest = this.test.filter(v => v == 2)
debugger
    if (num==2)
      this.viewtest = this.test
  }
}
