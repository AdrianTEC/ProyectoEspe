import { Component, OnInit } from '@angular/core';
import { SesionService } from 'src/app/Services/sesion-service.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  constructor(private sesionService: SesionService) {}
  user: any;
  ngOnInit(): void {
    this.user = this.sesionService.getUser();
  }

  logout(): void {
    this.sesionService.logout();
  }
}
