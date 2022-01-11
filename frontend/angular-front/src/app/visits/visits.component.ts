import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-visits',
  templateUrl: './visits.component.html',
  styleUrls: ['./visits.component.css']
})
export class VisitsComponent implements OnInit {

  displayedColumns: string[] = ['doctor', 'startDate', 'description'];
  dataSource: PeriodicElement[] = [];

  constructor(private data: DataService) {
    this.data.getVisits().subscribe(res => {
      console.log(res);
      this.dataSource = res;
    })
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
