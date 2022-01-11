import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DataService } from '../data.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email = '';
  password = '';

  constructor(public dataService: DataService, private router: Router) {
  }

  ngOnInit(): void {
  }

  login() {
    this.dataService.login(this.email, this.password)
      .subscribe(() => {
        console.log('sub')
        this.dataService.setLogged();
        this.router.navigateByUrl('new-visit');
      });
  }

}
