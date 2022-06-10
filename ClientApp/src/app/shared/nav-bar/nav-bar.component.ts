import { Component, OnInit } from '@angular/core';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SesionService } from 'src/app/Services/sesion-service.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  constructor(
    private sesionService: SesionService,
    private restApi: RestApiServiceService
  ) {}
  user: any;
  notifications: any[] = [
    {
      type: 0,
      description: 'Has sido aceptado',
    },
    {
      type: 1,
      description: 'Nuevo miembro',
    },
    {
      type: 2,
      description: 'Has enviado la solicitud',
    },
  ];
  ngOnInit(): void {
    this.user = this.sesionService.getUser();
    this.getNotifications();
  }
  /**
 *  
    {
    "id": 0,
    "type": 0,
    "notifiedPlayer": "string",
    "description": "string"
    }
 */
  getNotifications(): void {
    this.restApi
      .get_request('PlayerNotifications/' + this.user.username, null)
      .subscribe((value) => {
        this.notifications = value;
      });
  }
  logout(): void {
    this.sesionService.logout();
  }

  accept(notification: any): void {
    console.log('success');
  }
  reject(notification: any): void {}
}
