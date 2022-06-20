import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';

@Component({
  selector: 'app-results-view',
  templateUrl: './results-view.component.html',
  styleUrls: ['./results-view.component.css'],
})
export class ResultsViewComponent implements OnInit {
  dataSource: any[] = [];
  constructor(
    private rest: RestApiServiceService,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {}

  ngOnInit(): void {
    this.getResults();
  }

  getResults(): void {
    this.rest
      .get_request('RaceResults/' + this.data.id, null)
      .subscribe((result) => {
        console.log(result.data);
        this.dataSource = result.data;
      });
  }
}
