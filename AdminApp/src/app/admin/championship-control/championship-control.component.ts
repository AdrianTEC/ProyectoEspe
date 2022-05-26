import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddChampionshipModalComponent } from './add-championship-modal/add-championship-modal.component';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import {Championship} from 'src/app/models/models';
import * as moment from 'moment';
import {TopLeagueModalComponent} from './top-league-modal/top-league-modal.component';

@Component({
  selector: 'app-championship-control',
  templateUrl: './championship-control.component.html',
  styleUrls: ['./championship-control.component.css'],
})
export class ChampionshipControlComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private restService: RestApiServiceService
  ) {}

  ngOnInit(): void {
    this.getChampionships();
    // this.openAddMenu();
  }

  openAddMenu(): void {
    this.dialog
      .open(AddChampionshipModalComponent, {
        height: '80%',
        width: '80%',
        maxWidth: '900px',
        data: this.championships,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result) this.championships.push(result);
      });
  }

  openTopLeague(): void {
    this.dialog
      .open(TopLeagueModalComponent, {
        height: '80%',
        width: '80%',
        maxWidth: '900px',
        data: this.championships,
      });
  }

  getChampionships(): void {
    this.restService
      .get_request('Championships', null)
      .subscribe((response: Championship[]) => {
        if (response.length > 0) this.championships = response;
      });
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

  championships: Championship[] = [];
}
