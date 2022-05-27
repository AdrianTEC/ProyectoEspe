import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Driver } from 'src/app/models/models';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SesionService } from 'src/app/Services/sesion-service.service';

@Component({
  selector: 'app-my-portal',
  templateUrl: './my-portal.component.html',
  styleUrls: ['./my-portal.component.css'],
})
export class MyPortalComponent implements OnInit {
  pilots: Driver[] = [];
  constructor(
    private restApi: RestApiServiceService,
    private router: Router,
    private sesionService: SesionService
  ) {}

  myteams: any[] = [];
  ngOnInit(): void {
    this.getDrivers();
    localStorage.removeItem('currentAction');
  }

  /**
   * 
  [
  {
    "id": 0,
    "name": "string",
    "scuderia": {
      "id": 0,
      "name": "string",
      "price": 0
    },
    "drivers": [
      {
        "id": 0,
        "name": "string",
        "country": "string",
        "price": 0
      }
    ]
  }
]
   * 
   */
  getDrivers(): void {
    this.pilots.push;
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

  replaceComponent(component: any): void {
    localStorage.setItem('currentAction', 'replacing');
    localStorage.setItem('selectedDriver', JSON.stringify(component));
    this.router.navigateByUrl('/pages/store');
  }
  createNewTeam(): void {
    this.router.navigateByUrl('/pages/store');
    localStorage.setItem('currentAction', 'creatingTeam');
  }
}
