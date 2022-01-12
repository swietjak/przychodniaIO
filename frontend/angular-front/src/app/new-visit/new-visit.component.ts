import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DataService } from '../data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-new-visit',
  templateUrl: './new-visit.component.html',
  styleUrls: ['./new-visit.component.css'],
})
export class NewVisitComponent implements OnInit {
  specialization = '';
  medic = '';
  date = new FormControl(new Date());

  medics: any[] = [];
  specializations: any[] = [];
  visits = [];
  displayedColumns: string[] = ['time', 'availability'];

  constructor(
    private dataService: DataService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.dataService.getMedics().subscribe((res) => {
      console.log(res);
      this.medics = res;
    });
    this.dataService.getSpecializations().subscribe((res) => {
      console.log(res);
      this.specializations = res;
    });
  }

  search() {
    console.log('search');
    this.dataService
      .searchVisits({
        clinicId: this.specialization,
        date: this.date.value,
        medicId: this.medic,
      })
      .subscribe((visits) => {
        this.visits = visits;
      });
  }

  newVisit(element: any) {
    console.log(element);
    this.dataService
      .newVisit({
        id: element.id,
        patientId: 1, // TODO
        // medicId: '1', // TODO
      })
      .subscribe(() => {
        this.search();
        this.snackBar.open('Wizyta została umówiona');
      });
  }
}
