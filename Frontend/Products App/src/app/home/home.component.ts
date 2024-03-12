import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css', './home2.component.css'],
})
export class HomeComponent {
  constructor(private route: Router, private router: ActivatedRoute) {}

  navigateToItems() {
    this.route.navigate(['/items'], { relativeTo: this.router });
  }
}
