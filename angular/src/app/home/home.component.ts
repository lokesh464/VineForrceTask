import { AuthService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {

  state : boolean = false;
  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(private authService: AuthService) {}



  OnCountryClick(){
    this.state = false;
  }

  OnStateClick(){
    this.state = true;
  }


}
