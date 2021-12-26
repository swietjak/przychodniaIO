import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-visits',
  templateUrl: './visits.component.html',
  styleUrls: ['./visits.component.css']
})
export class VisitsComponent implements OnInit {

  displayedColumns: string[] = ['doctorName', 'specialization', 'date', 'description'];
  dataSource: PeriodicElement[] = [
    {
      doctorName: 'Kowlaski',
      specialization: 'No, ten dziecięcy na przykład',
      date: '2021-12-21',
      description: 'Pacjent się darł. Nie przyprowadzajcie go już.'
    },
    {
      doctorName: 'Rico',
      specialization: 'Dentysta',
      date: '2021-12-10',
      description: 'Ból zęba nie do zaleczenia. Należy wyrwać'
    }
  ]

  constructor() {
  }

  ngOnInit(): void {
  }
}

export interface PeriodicElement {
  doctorName: string;
  specialization: string;
  date: string;
  description: string;
}
