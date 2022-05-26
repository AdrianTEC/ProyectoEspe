import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {}

  login(username: string, password: string): void {
    this.router.navigateByUrl('/pages');
  }

  register(): void {
    this.router.navigateByUrl('/auth/register');
  }
}
