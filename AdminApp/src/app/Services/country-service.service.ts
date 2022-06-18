import { Injectable } from '@angular/core';
import * as countries from 'src/assets/countries.json';
import { Country } from '../models/models';
import { RestApiServiceService } from './rest-api-service.service';
@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor(private restapi: RestApiServiceService) {}
  allCountries: Country[] = [];

  getCountries(): string[] {
    let paises: string[] = [];
    this.restapi
      .get_requestByUrl('https://restcountries.com/v3.1/all', null)
      .subscribe((countriesData: any[]) => {
        countriesData.forEach((value) => {
          paises.push(value.name.common);
        });
      });
    return paises;
  }
}
