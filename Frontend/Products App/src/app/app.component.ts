import {
  Component,
  DoCheck,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { LoginService } from './services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Supplement';
  constructor(private loginService: LoginService, private route: Router) {
    if (localStorage.getItem('userToken')) {
      this.loginService.getLoggedInUser().subscribe({
        next: (response) => {
          console.log(response);
          this.loginService.loggedIn.next(true);
        },
        error: (error) => {
          console.log(error);
          this.loginService.loggedIn.next(false);
        },
      });
    }
  }

  ngOnInit() {}
}
