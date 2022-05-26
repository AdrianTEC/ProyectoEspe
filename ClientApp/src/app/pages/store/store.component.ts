import { Component, OnInit } from '@angular/core';
import { Driver, Scuderia } from 'src/app/models/models';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css'],
})
export class StoreComponent implements OnInit {
  pilots: Driver[] = [];
  scuderias: Scuderia[] = [];

  team1: any = {
    drivers: [],
    scudery: {},
  };
  team2: any = {
    drivers: [],
    scudery: {},
  };

  seeingDrivers: boolean = true;

  constructor(private restApi: RestApiServiceService) {}

  addPilotToCar(thing: any) {
    if (this.team1.drivers.length < 5) {
      this.team1.drivers.push(thing);
    } else {
      if (this.team2.drivers.length < 5) {
        this.team2.drivers.push(thing);
      }
    }
  }

  addCarToCar(thing: any) {
    if (this.objIsEmpty(this.team1.scudery)) {
      this.team1.scudery = thing;
    } else if (this.objIsEmpty(this.team2.scudery)) {
      this.team2.scudery = thing;
    }
  }
  objIsEmpty(value: any) {
    return Object.keys(value).length === 0;
  }
  ngOnInit(): void {
    this.getDrivers();
    this.getScuderias();
  }
  openDrivers(): void {
    this.seeingDrivers = true;
  }
  openCars(): void {
    this.seeingDrivers = false;
  }
  getDrivers(): void {
    this.pilots.push;
    this.restApi.get_request('Drivers', null).subscribe((result: any[]) => {
      this.pilots = result;
      this.pilots.forEach((driver) => {
        driver.country = 'https://countryflagsapi.com/png/' + driver.country;
      });
      console.log(this.pilots);
    });
  }
  getScuderias(): void {
    this.scuderias.push;
    this.restApi.get_request('Scuderias', null).subscribe((result: any[]) => {
      this.scuderias = result;
    });
  }
}
