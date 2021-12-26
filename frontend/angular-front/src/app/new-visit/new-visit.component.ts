import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms'
import { DataService } from '../data.service'
import { MatSnackBar } from '@angular/material/snack-bar'

@Component({
  selector: 'app-new-visit',
  templateUrl: './new-visit.component.html',
  styleUrls: ['./new-visit.component.css']
})
export class NewVisitComponent implements OnInit {

  specialization = '';
  medic = '';
  date = new FormControl(new Date());

  medics = [{
    id: '1',
    name: 'Michał Kalke'
  }, {
    id: '2',
    name: 'Halina Frąckowiak'
  }];
  specializations = [
    {
      id: '1',
      name: 'Specjalizacja 1'
    },
    {
      id: '2',
      name: 'Specjalizacja 2'
    },
    {
      id: '3',
      name: 'Specjalizacja 3'
    }
  ]
  visits = [];
  displayedColumns: string[] = ['time', 'availability'];

  constructor(private dataService: DataService, private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
  }

  search() {
    console.log('search')
    this.dataService.searchVisits({ date: this.date.value, medicId: this.medic })
      .subscribe(visits => {
        this.visits = visits;
      })
  }

  newVisit(element: any) {
    console.log(element)
    this.dataService.newVisit({
      startDate: element.startDate,
      endDate: element.endDate,
      patientId: '2', // TODO
      medicId: '2', // TODO
    }).subscribe(() => {
      this.search();
      this.snackBar.open('Wizyta została umówiona');
    })
  }
}
