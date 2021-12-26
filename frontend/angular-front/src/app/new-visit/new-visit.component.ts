import { ClassGetter } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';




@Component({
  selector: 'app-new-visit',
  templateUrl: './new-visit.component.html',
  styleUrls: ['./new-visit.component.css']
})
export class NewVisitComponent implements OnInit {

  isLogged = false;
  visits = [
    {
      time: "8:00",
      busy: false,
    },
    {
      time: "9:00",
      busy: true,
    },
    {
      time: "10:00",
      busy: false,
    },
    {
      time: "11:00",
      busy: false,
    }
  ];

  alertShow(){
    alert("Wizyta została umówiona")
  }
  doctors = ['Michał Kalke', 'Halina Frąckowiak'];

  constructor() { }

  ngOnInit(): void {
  }

  logged() {
    console.log('new-visit logged')
    this.isLogged = true;
  }

}
