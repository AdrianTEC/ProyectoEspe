import { Component, OnInit } from '@angular/core';
import { Driver, Scuderia } from 'src/app/models/models';
import { CheckerService } from 'src/app/Services/checker.service';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SesionService } from 'src/app/Services/sesion-service.service';
import { SwalService } from 'src/app/Services/swal-service.service';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css'],
})
export class StoreComponent implements OnInit {
  pilots: Driver[] = [];
  scuderias: Scuderia[] = [];
  currentAction: any = '';
  total: number = 0;
  team1: any = {
    drivers: [],
    scudery: {},
  };

  seeingDrivers: boolean = true;

  constructor(
    private restApi: RestApiServiceService,
    private sesionService: SesionService,
    private swalService: SwalService,
    private checker: CheckerService
  ) {}

  addPilotToCar(thing: any) {
    if (this.currentAction === 'replacing') {
      this.total = thing.price;
      const hasEnoughMoney = this.sesionService.getUser().money >= this.total;
      const componentBeingReplaced = JSON.parse(
        localStorage.getItem('selectedDriver') as any
      );

      if (hasEnoughMoney)
        this.swalService
          .htmloptionSwal(
            'Compra de un nuevo piloto',
            'Desear reemplazar : ' +
              componentBeingReplaced.name +
              '<br> por: ' +
              thing.name,
            'No',
            'Sí',
            '',
            null
          )
          .then((value) => {
            console.log(value);
          });
      else {
        this.swalService.showError(
          'Fondos insuficientes',
          'Actualmente no cuenta con los fondos para realizar esta compra'
        );
      }
      return;
    }

    if (this.team1.drivers.length < 5 && !this.team1.drivers.includes(thing)) {
      this.team1.drivers.push(thing);
      this.total += thing.price;
    } else
      this.swalService.showError(
        'Acción inválida',
        'No puede agregar mas de cinco pilotos ni agregar pilotos repetidos'
      );
  }

  addCarToCar(thing: any) {
    if (this.objIsEmpty(this.team1.scudery)) {
      this.team1.scudery = thing;
    }
  }
  objIsEmpty(value: any) {
    return Object.keys(value).length === 0;
  }
  ngOnInit(): void {
    this.currentAction = localStorage.getItem('currentAction');
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

  checkPayment(teamName: string, drivers: any): boolean {
    const hasEnoughMoney = this.sesionService.getUser().money >= this.total;
    const haveFiveDrivers = this.team1.drivers.length == 5;
    const haveAScudery = Object.values(this.team1.scudery).length > 1;
    const nameNotEmpty = this.checker.verifyName(teamName, 0, 60, true);
    if (!hasEnoughMoney) {
      this.swalService.showError(
        'Fondos insuficientes',
        'Actualmente no cuenta con los fondos para realizar esta compra'
      );
      return false;
    }
    if (!haveFiveDrivers || !haveAScudery) {
      this.swalService.showError(
        'Equipo incompleto',
        'Debe crear un equipo con 5 pilotos y una escudería'
      );
      return false;
    }

    if (!nameNotEmpty) {
      this.swalService.showError(
        'Nombre inválido',
        'Solo puede ingresar un conjunto de valores alfanuméricos no vacío'
      );

      return false;
    }

    return hasEnoughMoney && haveFiveDrivers && haveAScudery;
  }
  pay(teamName: string): void {
    const drivers = this.team1.drivers.map((driver: any) => {
      return driver.id;
    });

    if (this.checkPayment(teamName, drivers)) {
      const survey = {
        name: teamName,
        player: this.sesionService.getUser().username,
        scuderia: this.team1.scudery.id,
        drivers: drivers,
      };

      console.log(survey);
      this.submitPay(survey);
    }
  }

  submitPay(data: any) {
    this.restApi.post_request('PlayerTeams', data).subscribe((result) => {
      console.log(result);
      this.swalService.showSuccess(
        'Equipo creado',
        'El equipo fue creado con éxito'
      );
    });
  }
}
