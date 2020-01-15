import { Component, OnInit, OnDestroy } from '@angular/core';
import { book } from '../../../../classes/book';
import { RequestService } from '../../../../services/request/request.service';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit,OnDestroy {

list:book[]
  newBook:boolean
  chosen:book

  constructor(private req:RequestService) { }

  ngOnInit() {
    this.newBook=false
    this.chosen= new book();
    this.chosen.BookName="            "
    this.chosen.Bookinfo="             "

    delay(500)
   this.req.getBooks().subscribe(
     success=>{this.list= success,console.log(success)}
   )
  }
  createNewBookArea(){
    this.newBook= true;

  }
  ngOnDestroy(): void {

  }
}
