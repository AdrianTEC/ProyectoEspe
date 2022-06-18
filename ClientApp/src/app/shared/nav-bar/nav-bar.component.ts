import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
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
    private restApi: RestApiServiceService,
    private _snackBar: MatSnackBar
  ) {}
  myteams: any[] = [];
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
    this.getDrivers();
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
        console.log(value);

        this.notifications = value;
      });
  }
  logout(): void {
    this.sesionService.logout();
  }

  accept(notification: any): void {
    this.restApi
      .post_request('PlayerNotifications/accept/' + notification.id, null)
      .subscribe((result) => {
        this._snackBar.open('Nuevo miembro aceptado');
      });
  }
  reject(notification: any): void {
    this.restApi
      .delete_request('PlayerNotifications/decline/' + notification.id, null)
      .subscribe((result) => {
        if (notification.type === 1) this._snackBar.open('Solicitud Rechazada');
        if (notification.type === 2) this._snackBar.open('Solicitud cancelada');

        this.notifications = this.notifications.filter((object) => {
          return object.id !== notification.id;
        });
      });
  }

  getDrivers(): void {
    this.restApi
      .get_request('PlayerTeams/' + this.sesionService.getUser().username, null)
      .subscribe((result: any[]) => {
        this.myteams = result;

        this.myteams.forEach((team) => {
          team.drivers.forEach((driver: any) => {
            driver.country =
              'https://countryflagsapi.com/png/' + driver.country;
          });
        });
      });
  }
}
