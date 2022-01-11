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

  setLogged() {
    this.logged = true;
  }

  login(email: string, password: string): Observable<any> {
    // TODO LOGIN
    //kazdy - return of({});
    return this.http.post(`https://localhost:5001/api/Login`, { email, password });
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

  searchVisits(data: SearchVisitRequest): Observable<any> {
    console.log(data);
    //return this.http.post('/backend-url', data);
    return this.http.get('https://localhost:5001/api/Visit/1');
  }

  newVisit(data: any): Observable<any> {
    return this.http.post(`https://localhost:5001/api/Visit/${data.id}/book`, data);
  }
}

interface SearchVisitRequest {
  medicId: string;
  date: string;
}