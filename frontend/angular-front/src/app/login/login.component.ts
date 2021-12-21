import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Output()
  login = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }
  show=false;
 logged(){

  this.show=false;
 }

 

}
