import { Component, OnInit } from '@angular/core';
import { AddLearningService } from '../../../services/addLearning/add-learning.service';
import { JsonPipe } from '@angular/common';
import { offer } from '../../../classes/offer';
import { Observable } from 'rxjs';
import { matching } from 'src/app/classes/matching';

@Component({
  selector: 'app-learner-screen',
  templateUrl: './learner-screen.component.html',
  styleUrls: ['./learner-screen.component.css']
})
export class LearnerScreenComponent implements OnInit {

  data: any;
  cards: Array<any>
  // [{"reqId":1004,"donorName":"avraham","donorEmail":"avra@gmail.com","reqPurpose":"להצלחת הפרויקט","BookId":2,"BookName":null,"timeId":2,"timeDesc":null,"reqStartDate":null,"reqEndDate":null,"sosDate":null,
  // "payment":0.0,"sosPayment":0.0,"occuptionId":null,"genderid":null,"password":"123456","extraInfo":null}]
  settings = {
    actions: {
      columnTitle: '',
      position: 'right',
    },
  delete: {
    confirmDelete: true,

    deleteButtonContent: '<i class="pi pi-trash" aria-hidden="true"></i>' ,
    saveButtonContent: 'שמור',
    cancelButtonContent: 'בטול'
  },
  add: {
    confirmCreate: true,
    addButtonContent: 'הוסף',
    createButtonContent: 'צור',
    cancelButtonContent: 'מחיקה',
  },
  edit: {
    confirmSave: true,
    editButtonContent:'<i class="pi  pi-pencil" aria-hidden="true"></i>',  
    saveButtonContent: 'שמור',
    cancelButtonContent: 'ביטול',
  },
  columns: {
        BookName: {
          title: 'שם הספר'
        },
        extraInfo: {
          title: 'מידע נוסף'
        },
        reqStartDate: {
          title: 'תאריך התחלה'
        },
        reqEndDate: {
          title: 'תאריך סיום',
        },
        timeDesc: {
          title: 'תדירות'
        },
        payment: {
          title: 'סכום המילגה'
        },
        reqPurpose: {
          title: 'מוקדש ל:'
        }
        
      },
};





  // settings = {
  //   actions: {
  //     columnTitle: 'פעולות',
  //     position: 'right',
  //     add:true,
  //     edit:true,
  //     delete:true

    
  //   },

  //   add: {
  //     addButtonContent: 'הוסף',
  //     createButtonContent: 'צור',
  //     cancelButtonContent: 'מחיקה',
  //   },
  //   edit: {
  //     editButtonContent: 'עדכן',
  //     saveButtonContent: 'שמור',
  //     cancelButtonContent: 'ביטול',
  //   },
  //   delete: {
  //     deleteButtonContent: 'מחק',
  //   },


  //   columns: {
  //     BookName: {
  //       title: 'שם הספר'
  //     },
  //     extraInfo: {
  //       title: 'מידע נוסף'
  //     },
  //     reqStartDate: {
  //       title: 'תאריך התחלה'
  //     },
  //     reqEndDate: {
  //       title: 'תאריך סיום',
  //     },
  //     timeDesc: {
  //       title: 'תדירות'
  //     },
  //     payment: {
  //       title: 'סכום המילגה'
  //     },
  //     reqPurpose: {
  //       title: 'מוקדש ל:'
  //     }
      
  //   },
  //   mode:'external',
  //   noDataMessage:"לא נמצאו נתונים"
  // };
  offers: Array<offer>

show

  private readonly newProperty = this;

  constructor(private addService: AddLearningService) {}

  ngOnInit() {
  this.show=false
this.data= new Array<any>()
    // this.route.params
    // .subscribe((paramsFromUrl: Params) => {
    //    console.log("paramsFromUrl!!!", paramsFromUrl);
    //    this.id = paramsFromUrl.id;
    //    this.name = paramsFromUrl.name;
    // });
    this.cards = ["hello", "how ", "are", "you", "today"]
    this.addService.getCurrentRequests().subscribe(success => {  this.offers = (success),this.onSuccess()} )
   
   
  }

  onSuccess(){
    console.log("BookName:"+ this.offers[0].reqPurpose +"extraInfo:"+ this.offers[0].extraInfo) 
    for (let i = 0; i < this.offers.length; i++) {

      this.data.push
        ({
          BookId:this.offers[i].BookId,
          BookName: this.offers[i].BookName, extraInfo: this.offers[i].extraInfo,
          reqStartDate: this.offers[i].reqStartDate, reqEndDate: this.offers[i].reqEndDate,
          timeDesc: this.offers[i].timeDesc, payment: this.offers[i].payment,
          reqPurpose: this.offers[i].reqPurpose
        });
        this.show=true
    }
  }
  onDeleteConfirm(event) {
    //alert("onDeleteConfirm");
    console.log(event.data)
    console.log(sessionStorage["getItem(currentLearner)"])
     let req= event.data as offer
     console.log("req is:")
     console.log(req)
     
    // (new Matching() { learnerId = l.learnerId, bookId = newReqeust.BookId, reqId = newReqeust.reqId, amount = 1 }));
   console.log( this.addService.addLearning 
    ( new matching ( sessionStorage.getItem("currentLearner") as unknown as number, req.BookId, 1005, 1 )).subscribe(success=>{console.log("i got it")}))
    //console.log(event);
   // if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    //} else {
   //   event.confirm.reject();
   // }
  }
  
  onCreateConfirm(event) {
    alert("onCreateConfirm")
    console.log("Create Event In Console")
    console.log(event);
    // this.newProperty.addService.addLearning()
    event.confirm.resolve();
  
  }
  
  onSaveConfirm(event) {
    alert("onSaveConfirm")
    console.log("Edit Event In Console")
    console.log(event);
    event.confirm.resolve();
  }
  // myCreate(add){
  //   console.log(add.index);
  // }
}

