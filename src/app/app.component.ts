import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from './services/user/user.service';
import { person } from './classes/person';
import { NbTabsetModule } from '@nebular/theme';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  data: { id: number; name: string; username: string; email: string; }[];
  cards: string[]
  kind: number = 5
  title = 'learning';
  tabs = [
    {
      title: 'לומד',
      route: '/login/0',

      responsive: true, // hide title before `route-tabs-icon-only-max-width` value
    },
    {
      title: 'תורם',
      route: '/login/1',
    }
  ];

  items = [{ title: 'Profile', link: '/profile' },
  { title: 'Log out', link: '/login/1' }];
  data1: person[]
  settings = {
    actions: {
      columnTitle: 'פעולות',
      position: 'right',
    },

    add: {
      addButtonContent: 'הוסף',
      createButtonContent: 'צור',
      cancelButtonContent: 'מחיקה',
    },
    edit: {
      editButtonContent: 'עדכן',
      saveButtonContent: 'שמור',
      cancelButtonContent: 'ביטול',
    },
    delete: {
      deleteButtonContent: 'מחק',
    },


    columns: {
      email: {
        title: 'מייל'
      },
      username: {
        title: 'שם משתמש'
      },
      name: {
        title: 'שם'
      },
      id: {
        title: 'קוד',
      }
    }
  };

  //  data = [this.data1]
  

  constructor(private router: Router, private route: ActivatedRoute, private service: UserService) { }
  ngOnInit(): void {

    this.cards = ["hello", "how ", "are", "you", "today"]
    this.data = [
      {
        id: 1,
        name: 'רחל בילא ונדרר',
        username: 'רחל בילא',
        email: 'rochel@gmail.com'
      },
      {
        id: 2,
        name: 'אסתר ונדרר',
        username: 'אסתר החמודה!!',
        email: 'esther@gmail.com'
      },
      // ... other rows here
      {
        id: 11,
        name: ' צפורה ונדרר ',
        username: 'ציפורה',
        email: 'tz@gmail.com'
      }
    ];
    // this.service.getAllPeople().subscribe(success=>{this.data1=success;console.log(success[0].email);},e=>{console.log("error "+e.massage)});
  }
  login(num: number) {
    // if(document.getElementById("1").getAttribute("active"))
    // this.router.navigate(['login/'+1]);
    // if(document.getElementById("0").getAttribute("active"))
    // this.router.navigate(['login/'+0]);
    // this.router.navigate(['login/'+sessionStorage.getItem("kind")]);
    this.router.navigate(['login/' + num]);
  }
  // loadNext(){
  //   this.items= this.items;
  // }
}
