import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-donor-screen',
  templateUrl: './donor-screen.component.html',
  styleUrls: ['./donor-screen.component.css']
})
export class DonorScreenComponent implements OnInit {

  constructor( private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
  }
newl(){
  this.router.navigate(['/purpose']);
}
}
