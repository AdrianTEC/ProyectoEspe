import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Driver } from 'src/app/models/models';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SesionService } from 'src/app/Services/sesion-service.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  pilots: Driver[] = [];
  top: any[] = [];
  constructor(
    private restApi: RestApiServiceService,
    private router: Router,
    private sesionService: SesionService,
    private route: ActivatedRoute
  ) {}
  user: any;
  myteams: any[] = [];
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.restApi
        .get_request('Players/' + params.userName, null)
        .subscribe((value) => {
          console.log(value);

          this.user = value;
          this.getDrivers();
          this.getTop();
          //this.fillWithDummy();
          this.sortTop();
        });
    });
  }

  getDrivers(): void {
    this.pilots.push;
    this.restApi
      .get_request('PlayerTeams/' + this.user.username, null)
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
