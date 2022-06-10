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
  top: any[] = [];
  constructor(
    private restApi: RestApiServiceService,
    private router: Router,
    private sesionService: SesionService
  ) {}

  myteams: any[] = [];
  ngOnInit(): void {
    this.getDrivers();
    this.getTop();


    localStorage.removeItem('currentAction');
    this.sesionService.getUserFromDb(this.sesionService.getUser().username);
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
  getTop(): void {
    this.restApi
      .get_request('PublicLeague', null)
      .subscribe((result: any[]) => {
        console.log(result);
        this.top = result;
        this.sortTop();
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

  sortTop(): void {
    const x = this.top;
    x.sort((value1, value2) => {
      return value2.score - value1.score;
    });
    this.top = x;
  }

  fillWithDummy(): void {
    this.restApi
      .get_requestByUrl(
        'https://random-word-api.herokuapp.com/word?number=10',
        null
      )
      .subscribe((words) => {
        words.forEach((word: string) => {
          this.top.push({
            playerUsername: word,
            teamName: word,
            score: Math.floor(Math.random() * 500),
          });
        });
      });
  }

  openProfile(userName: string): void {
    this.router.navigate(['pages/profile'], {
      queryParams: { userName: userName },
    });
  }
}
