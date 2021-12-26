import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private logged = false;

  constructor() {
  }

  get isLogged() {
    return this.logged;
  }

  login(): Observable<any> {
    // TODO LOGIN
    this.logged = true;
    return of({});
  }
}
