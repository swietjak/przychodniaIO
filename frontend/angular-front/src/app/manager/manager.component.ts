import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

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

  doctors = ['Michał Kalke', 'Halina Frąckowiak'];

  logged() {
    console.log('client logged')
    this.isLogged = true;
  }
}
