import { Component, OnInit, ViewChild } from '@angular/core';
import interactionPlugin from '@fullcalendar/interaction';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import resourceTimelinePlugin from '@fullcalendar/resource-timeline';
import { OptionsInput } from '@fullcalendar/core';
import heLocale from '@fullcalendar/core/locales/he';
import bootstrapPlugin from '@fullcalendar/bootstrap';
import { Event } from '@angular/router';
import CalendarComponent from '@fullcalendar/core/CalendarComponent';
import { FullCalendarComponent } from '@fullcalendar/angular';


@Component({
  selector: 'app-calender',

  templateUrl: './calender.component.html',
  styleUrls: ['./calender.component.css']
})
export class CalenderComponent implements OnInit {
@ViewChild ('myCalender') myCalender :FullCalendarComponent;
 events:any
 events1:any
 changeDaf= false;
 eventsDafHayomei:any
 options:any
  title = 'myprime';
visibleEvents: any;
  /**
   *
   */
  constructor() {


  }
  calendarPlugins = [dayGridPlugin, timeGridPlugin, interactionPlugin,bootstrapPlugin];
  themeSystem: 'bootstrap';
  ngOnInit(){
// this.events1=


   this.events= {
    // url:"https://www.hebcal.com/hebcal/?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&year=now&month=x&ss=on&mf=on&c=on&geo=geoname&geonameid=3448439&m=50&s=on",
    url:"https://www.hebcal.com/hebcal/?v=1&cfg=fc&maj=on&min=on&nx=on&mf=on&ss=on&o=on&s=on&i=on&year=2019&month=x&yt=G&lg=h&d=on&c=on",
    // url: "https://www.hebcal.com/hebcal/?v=1&cfg=fc&maj=on&min=on&mod=off&nx=off&month=x&ss=on&mf=off&c=off&geo=none&lg=ah&d=on",
    cache: true,
    textColor: 'blue',
    color:'transparent',
    selectable:false

}
this.eventsDafHayomei = {

  url:"https://www.hebcal.com/hebcal/?v=1&cfg=fc&F=on&i=on&year=2019&month=x&yt=G&lg=h&c=off&geo=geoname&zip=&city=&geonameid=&b=18&m=50&.s",

  cache: true,
  textColor: 'lightblue',
  color:'transparent',
  selectable:false

}
this.events1= {
  url: "http://localhost:62299/api/learner/GetCurrentLearningDates/",
  cache: true,
  color: 'lightgray',   // an option!
  textColor: 'black',
  borderColor:'blue',
  allDay: true
}
this.visibleEvents=[this.events1,this.events];
this.options = {
  customButtons: {
    myCustomButton: {
      text: 'custom!',
    }
  }
};
// <p-schedule #cal [events]="events"
//                [header]="header"
//                [options]="options">
// </p-schedule>

console.log(this.events);
console.log(this.events1);

}

  dateClick(model)
  {

  alert(model.date)
  }
 a(m)
 {

   alert("olil");
 }


EventClick(e){
  console.log(e);
if(e.event.id!="")

alert(e.event.id)
}
changeDafHayomei()
{
  if(this.changeDaf==true)
  // this.visibleEvents = this.visibleEvents.concat(this.eventsDafHayomei)
  this.visibleEvents=[this.events1,this.events,this.eventsDafHayomei]
  // this.myCalendar.fullCalendar('changeView', view);
  else
  // this.visibleEvents = this.visibleEvents.remove(this.eventsDafHayomei)
  this.visibleEvents= [this.events1,this.events]
  this.changeDaf=!this.changeDaf;
this.myCalender.eventSources=this.visibleEvents;
}
}

