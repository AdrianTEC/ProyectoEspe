import { Component, OnInit } from '@angular/core';
import {Championship, Team} from '../../../models/models';
import {RestApiServiceService} from '../../../Services/rest-api-service.service';

@Component({
  selector: 'app-top-league-modal',
  templateUrl: './top-league-modal.component.html',
  styleUrls: ['./top-league-modal.component.css']
})
export class TopLeagueModalComponent implements OnInit {

  teams: Team[] = [];
  activeChampionship: Championship | undefined;

  constructor(private restService: RestApiServiceService) { }

  ngOnInit(): void {
    this.getActiveChampionship();
    this.getTeams();
    this.teams.sort((a, b) => b.score - a.score);
  }

  getActiveChampionship(): void {
    this.restService
      .get_request('Championships/active', null)
      .subscribe((response: Championship) => {
        if (response) { this.activeChampionship = response; }
      });
  }

  getTeams(): void {
    this.restService
      .get_request('Teams', null)
      .subscribe((response: Team[]) => {
        if (response.length > 0) { this.teams = response; }
      });
  }



}
