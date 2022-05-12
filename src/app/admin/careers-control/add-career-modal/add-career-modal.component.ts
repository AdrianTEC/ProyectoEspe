import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { Championship, Country, Race } from 'src/app/models/models';
import { CountryService } from 'src/app/Services/country-service.service';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SwalService } from 'src/app/Services/swal-service.service';

@Component({
  selector: 'app-add-career-modal',
  templateUrl: './add-career-modal.component.html',
  styleUrls: ['./add-career-modal.component.css'],
})
export class AddCareerModalComponent implements OnInit {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.code === 'KeyY') {
      this.submit({
        actualState: '',
        championshipId: 'NE0LEQ',
        country: 'Åland Islands',
        finishingDate: '7/10/2043',
        finishingTime: '15:38',
        id: 0,
        name: 'Carrera Automatica',
        startingDate: '5/10/2043',
        startingTime: '22:40',
        trackName: 'Pista automatica',
      });
    }
  }

  constructor(
    private swal: SwalService,
    private restService: RestApiServiceService,
    @Inject(MAT_DIALOG_DATA) public races: Race[],
    public dialogRef: MatDialogRef<AddCareerModalComponent>,
    private countryServices: CountryService
  ) {}

  countries: string[] = [];
  championships: Championship[] = [];

  ngOnInit(): void {
    this.countries = this.countryServices.getCountries();
    this.getChampionships();
  }

  validDate(date: string): boolean {
    const result = this.toDate(date).isValid();
    return result;
  }

  verifyFieldsAreFill(c: Race): boolean {
    if (
      c.name === '' ||
      c.trackName === '' ||
      c.country === '' ||
      c.championshipId === '' ||
      c.startingTime === '' ||
      c.finishingTime === '' ||
      c.startingDate === '' ||
      c.finishingDate === ''
    ) {
      this.swal.showError(
        'Datos insuficientes',
        'Los datos suministrados son insuficientes. Por favor verifique de nuevo los valores ingresados e intente de nuevo'
      );
      return false;
    }
    return true;
  }

  verifyDateisAfterToday(c: Race): boolean {
    const now = moment();
    const finish = this.toDate(c.finishingDate);
    const begin = this.toDate(c.startingDate);
    if (finish < begin || now > begin) {
      this.swal.showError(
        'Fecha inválida',
        'No se pueden crear carreras en el pasado o con fecha de finalización previa al inicio, por favor corrija las fechas introducidas e intente de nuevo'
      );
      return false;
    }
    return true;
  }

  verifyRaceCollision(newRace: Race): boolean {
    const newBegindate = this.toDate(newRace.startingDate);
    const newEnddate = this.toDate(newRace.finishingDate);

    for (let i = 0; i < this.races.length; i++) {
      const c = this.races[i];
      const beginDate = this.toDate(c.startingDate);
      const endDate = this.toDate(c.finishingDate);

      const inRange =
        (newBegindate.isSameOrAfter(beginDate) && newBegindate.isSameOrBefore(endDate)) ||
        (newEnddate.isSameOrAfter(beginDate) && newEnddate.isSameOrBefore(endDate)) ||
        (newBegindate.isBefore(beginDate) && newEnddate.isAfter(endDate));

      if (inRange) {
        this.swal.showError(
          'Fecha inválida',
          'Ya existe una carrera en las fechas especificadas, porfavor corrija las fechas e intentelo de nuevo  ' +
            'La carrera de choque corresponde a: ' +
            c.name
        );
        return false;
      }
    }
    return true;
  }

  verifyRaceInChampionshipRange(newRace: Race): boolean {
    const newBegindate = this.toDate(newRace.startingDate);
    const newEnddate = this.toDate(newRace.finishingDate);
    const championship = this.championships.filter(c => c.id === newRace.championshipId)[0];

    console.log(championship.id);

    const beginDate = this.toDate(championship.startingDate);
    const endDate = this.toDate(championship.finishingDate);
    const inRange =
      (newBegindate.isSameOrAfter(beginDate) && newBegindate.isSameOrBefore(endDate)) &&
      (newEnddate.isSameOrAfter(beginDate) && newEnddate.isSameOrBefore(endDate));

    if (!inRange) {
      this.swal.showError(
        'Fecha inválida',
        'La fecha ingresada no está en el rango del campeonato');
      return false;
    }
    return true;
  }

  verifyRaceIsValid(race: Race): boolean {
    if (
      !this.verifyFieldsAreFill(race) ||
      !this.verifyDateisAfterToday(race) ||
      !this.verifyRaceCollision(race) ||
      !this.verifyRaceInChampionshipRange(race)
    ) {
      return false;
    }
    return true;
  }

  submit(race: Race) {
    race.startingTime = moment(race.startingTime, 'h:mm a').format('h:mm a');
    race.finishingTime = moment(race.finishingTime, 'h:mm a').format('h:mm a');

    if (!this.verifyRaceIsValid(race)) return;
    this.uploadRace(race);
  }

  uploadRace(race: Race) {
    this.restService.post_request('Races', race).subscribe((result) => {
      this.swal.showSuccess(
        'Campeonato creado con éxito',
        ' Se ha creado el campeonato de manera exitosa'
      );
      this.dialogRef.close(race);
    });
  }

  toDate(date: string) {
    return moment(date, 'DD/MM/YYYY');
  }

  getChampionships(): void {
    this.restService
      .get_request('Championships', null)
      .subscribe((response) => {
        this.championships = response;
      });
  }
}
