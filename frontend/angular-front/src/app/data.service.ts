import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private logged = false;

  constructor(private http: HttpClient) {}

  get isLogged() {
    return this.logged;
  }

  setLogged() {
    this.logged = true;
  }

  login(email: string, password: string): Observable<any> {
    // TODO LOGIN
    //kazdy - return of({});
    return this.http.post(`https://localhost:5001/api/Login`, {
      email,
      password,
    });
  }

  getVisits(): Observable<any> {
    return this.http.get('https://localhost:5001/api/Visit/1/patient-visits');
  }

  getSpecializations(): Observable<any> {
    return this.http.get('https://localhost:5001/api/Specialization');
  }

  getMedics(): Observable<any> {
    return this.http.get('https://localhost:5001/api/Medic');
  }

  searchVisits({ clinicId, ...params }: SearchVisitRequest): Observable<any> {
    console.log(params);
    const httpParams = new HttpParams({
      fromObject: {
        medicId: params.medicId,
        date: params.date.toISOString(),
      },
    });
    //return this.http.post('/backend-url', data);
    return this.http.get(`https://localhost:5001/api/Visit/${clinicId}`, {
      params: httpParams,
    });
  }

  newVisit({ id, ...data }: BookVisitRequest): Observable<any> {
    return this.http.put(`https://localhost:5001/api/Visit/${id}/book`, data);
  }
}

interface SearchVisitRequest {
  medicId: string;
  date: Date;
  clinicId: string;
}

interface BookVisitRequest {
  id: string;
  patientId: number;
}
