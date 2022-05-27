import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class SesionService {
  constructor(private router: Router) {}

  setUser(data: any): void {
    localStorage.setItem('User', data);
  }

  getUser(): any {
    const value = localStorage.getItem('User');
    if (value) return JSON.parse(value);
    else return null;
  }
  logout(): void {
    localStorage.removeItem('User');
    this.router.navigateByUrl('/auth');
  }
}
