import { Component, DoCheck, OnDestroy, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Login } from '../models/login';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginData: Login = new Login('', '');
  errorMessage: string = '';
  hasError: boolean = false;
  isLoading: boolean = false;
  constructor(
    private loginService: LoginService,
    private route: Router,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {}

  onLogin() {
    this.isLoading = true;
    this.loginService.login(this.loginData).subscribe({
      next: (responseData: any) => {
        console.log(responseData);
        if (responseData.isSuccess) {
          localStorage.setItem('userToken', responseData.result);
          this.loginService.loggedIn.next(true);
          this.route.navigate(['/items'], { relativeTo: this.router });
          this.hasError = false;
          this.isLoading = false;
        } else {
          this.errorMessage = 'Invalid username or password!';
          this.hasError = true;
          this.isLoading = false;
        }
      },
      error: (err) => {
        this.errorMessage = 'Invalid username or password!';
        this.hasError = true;
        this.isLoading = false;

        console.clear();
      },
    });
  }
}
