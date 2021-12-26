import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs'
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private logged = false;

  constructor(private http: HttpClient) {
  }

  get isLogged() {
    return this.logged;
  }

  login(): Observable<any> {
    // TODO LOGIN
    this.logged = true;
    return of({});
  }

  searchVisits(data: SearchVisitRequest): Observable<any> {
    console.log(data);
    //return this.http.post('/backend-url', data);
    return of([
        {
          id: '1',
          startDate: '8:00',
          endDate: '9:00',
          availability: true,
        },
        {
          id: '2',
          startDate: '9:00',
          endDate: '10:00',
          availability: false,
        },
        {
          id: '3',
          startDate: '10:00',
          endDate: '11:00',
          availability: false,
        },
        {
          id: '4',
          startDate: '11:00',
          endDate: '12:00',
          availability: true,
        }
      ]
    )
  }

  newVisit(data: NewVisitRequest): Observable<any> {
    console.log(data);
    return of({});
  }
}

interface SearchVisitRequest {
  medicId: string;
  date: string;
}

interface NewVisitRequest {
  patientId: string;
  medicId: string;
  startDate: string;
  endDate: string;
}
