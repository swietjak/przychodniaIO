import { ClassGetter } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

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
      time: "8:00",
      busy: false,
    },
    {
      time: "8:00",
      busy: false,
    }
  ];

  doctors = ['Michał Kalke', 'Halina Frąckowiak'];

  constructor() { }

  ngOnInit(): void {
  }

  logged() {
    console.log('client logged')
    this.isLogged = true;
  }

}
