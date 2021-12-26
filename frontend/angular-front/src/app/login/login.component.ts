import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DataService } from '../data.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public dataService: DataService, private router: Router) {
  }

  ngOnInit(): void {
  }

  login() {
    // TODO logowanie
    this.dataService.login()
      .subscribe(() => {
        console.log('sub')
        this.router.navigateByUrl('new-visit');
      });
  }

}
