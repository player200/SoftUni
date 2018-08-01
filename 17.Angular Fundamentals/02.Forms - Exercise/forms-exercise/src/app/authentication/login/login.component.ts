import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from '../models/login.model';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: LoginModel
  loginFailed: boolean
  errorMessage: string

  constructor(private authService: AuthService,
    private router: Router) {
    this.model = new LoginModel('', '');
  }

  login() {
    this.authService.login(this.model)
      .subscribe(data => {
        this.successfulLoggedIn(data)
      }, error => {
        this.loginFailed = true
        this.errorMessage = error.error.description
      })
  }

  successfulLoggedIn(data) {
    this.authService.authtoken = data['_kmd']['authtoken']
    localStorage.setItem('authtoken', data['_kmd']['authtoken'])
    localStorage.setItem('username', data['username'])
    this.router.navigate(['/home'])
  }

  ngOnInit() {
  }

}
