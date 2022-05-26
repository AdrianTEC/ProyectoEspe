import { Injectable } from '@angular/core';
import * as countries from 'src/assets/countries.json';
import { Country } from '../models/models';
@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor() {}
  allCountries: Country[] = [];

  getCountries(): string[] {
    let paises: string[] = [];
    const countryJson: any = countries;
    this.allCountries = countryJson.default; //ESTO SE HACE ASI POR UN ERROR DEL COMPILADOR DE TYPESCRIPT
    this.allCountries.forEach((country) => {
      paises.push(country.name);
    });
    return paises;
  }
}
