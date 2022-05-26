import { Component, OnInit } from '@angular/core';
import { Driver } from 'src/app/models/models';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';

@Component({
  selector: 'app-my-portal',
  templateUrl: './my-portal.component.html',
  styleUrls: ['./my-portal.component.css'],
})
export class MyPortalComponent implements OnInit {
  pilots: Driver[] = [];
  constructor(private restApi: RestApiServiceService) {}

  ngOnInit(): void {
    this.getDrivers();
  }

  getDrivers(): void {
    this.pilots.push;
    this.restApi.get_request('Drivers', null).subscribe((result: any[]) => {
      this.pilots = result.splice(0, 5); //REMOVER ESTO
      this.pilots.forEach((driver) => {
        driver.country = 'https://countryflagsapi.com/png/' + driver.country;
      });
      console.log(this.pilots);
    });
  }
}
