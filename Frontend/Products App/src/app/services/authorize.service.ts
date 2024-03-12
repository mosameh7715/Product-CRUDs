import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthorizeService {
  isAdmin: boolean = false;

  constructor(
    private loginService: LoginService,
    private route: Router,
    private router: ActivatedRoute
  ) {}

  validateToken() {
    if (localStorage.getItem('userToken')) {
      this.isAdmin = true;
    } else {
      this.isAdmin = false;
    }

    return this.isAdmin;
  }
}
