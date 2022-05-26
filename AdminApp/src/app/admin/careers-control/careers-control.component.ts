import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { Championship, Race, RaceAux } from 'src/app/models/models';
import * as moment from 'moment';
import { AddCareerModalComponent } from './add-career-modal/add-career-modal.component';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-careers-control',
  templateUrl: './careers-control.component.html',
  styleUrls: ['./careers-control.component.css'],
})
export class CareersControlComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private restService: RestApiServiceService
  ) {}
  races: RaceAux[] = [];

  ngOnInit(): void {
    this.getRaces();
    //this.openAddMenu();
  }

  openAddMenu(): void {
    this.dialog
      .open(AddCareerModalComponent, {
        height: '80%',
        width: '80%',
        maxWidth: '900px',
        data: this.races,
      })
      .afterClosed()
      .subscribe((race: RaceAux) => {
        if (!race) return;
        this.getChampionshipName(race.championshipId).subscribe(
          (championship: Championship) => {
            race.championshipName = championship.name;
            this.races.push(race);
          }
        );
      });
  }

  getRaces(): void {
    this.restService.get_request('Races', null).subscribe((races) => {
      races.forEach((race: RaceAux) => {
        this.getChampionshipName(race.championshipId).subscribe(
          (championship: Championship) => {
            race.championshipName = championship.name;
            this.races.push(race);
            console.log(this.races);
          }
        );
      });
    });
  }

  getChampionshipName(id: string): Observable<any> {
    return this.restService.get_request('Championships/' + id, null);
  }

  calcChampionshipState(beginDate: string, endDate: string): string {
    const bDate = moment(beginDate, 'DD-MM-YYYY HH:mm');
    const eDate = moment(endDate, 'DD-MM-YYYY HH:mm');
    const todayDate = moment();

    if (todayDate >= bDate && todayDate < eDate) return '0';
    if (todayDate < bDate) return '1';
    if (todayDate > eDate) return '2';
    return '0';
  }
}
