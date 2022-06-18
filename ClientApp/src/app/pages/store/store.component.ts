import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NavigationEnd, Router } from '@angular/router';
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
  shoppingCarTeam: any = {
    drivers: [],
    scudery: null,
  };

  money: number = 0;
  moneyCounter: any;
  seeingDrivers: boolean = true;

  constructor(
    private restApi: RestApiServiceService,
    private sesionService: SesionService,
    private swalService: SwalService,
    private checker: CheckerService,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {}
  ngOnInit(): void {
    this.currentAction = localStorage.getItem('currentAction');

    if (this.currentAction === 'replacing') {
      this.shoppingCarTeam = this.getTeamFromLocalStorage();
      console.log(this.shoppingCarTeam);
    }

    this.getDrivers();
    this.getScuderias();

    this.suscribeToMoneyCounter();
  }

  getTeamFromLocalStorage(): any {
    const team = JSON.parse(localStorage.getItem('team') as any);
    console.log(team);
    if (team) return team;
  }

  addPilotToCar(thing: any): any {
    if (
      this.shoppingCarTeam.drivers.length < 5 &&
      !this.shoppingCarTeam.drivers.includes(thing)
    ) {
      this.shoppingCarTeam.drivers.push(thing);
      this.calcTotal(thing.price);

      this._snackBar.open('Piloto Agregado', '', {
        duration: 1000,
      });
      return this.shoppingCarTeam;
    } else
      this.swalService.showError(
        'Acción inválida',
        'No puede agregar mas de cinco pilotos ni agregar pilotos repetidos'
      );
  }

  addCarToCar(thing: any) {
    if (
      this.shoppingCarTeam.scudery != null &&
      Object.values(this.shoppingCarTeam.scudery).length > 0
    )
      this.calcTotal(-this.shoppingCarTeam.scudery.price);
    this.shoppingCarTeam.scudery = thing;
    this.calcTotal(thing.price);
    this._snackBar.open('Escudería cambiada', '', {
      duration: 3000,
    });
  }

  sellIScudery(): void {
    this.calcTotal(-this.shoppingCarTeam.scudery.price);
    this.shoppingCarTeam.scudery = null;
  }
  sellIDriver(driver: any): void {
    const drivers: any[] = this.shoppingCarTeam.drivers;
    for (let i = 0; i < drivers.length; i++) {
      if (drivers[i] === driver) {
        drivers.splice(i, 1);
        this.calcTotal(-driver.price);
      }
    }
  }

  objIsEmpty(value: any) {
    return Object.keys(value).length === 0;
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

  checkPayment(team: any, drivers: any): boolean {
    if (!team) {
      this.swalService.showError(
        'Nombre inválido',
        'Solo puede ingresar un conjunto de valores alfanuméricos no vacío'
      );

      return false;
    }
    const teamName = team;
    const hasEnoughMoney = this.sesionService.getUser().money >= this.total;
    const haveFiveDrivers = this.shoppingCarTeam.drivers.length == 5;
    const haveAScudery = Object.values(this.shoppingCarTeam.scudery).length > 1;
    const nameNotEmpty = this.checker.verifyName(teamName, 0, 60, true);
    if (!hasEnoughMoney) {
      this.showInsuficientFoundsError();
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
      this.showPilotMaxError();

      return false;
    }

    return hasEnoughMoney && haveFiveDrivers && haveAScudery;
  }

  pay(): void {
    const teamName = (document.getElementById('teamName') as HTMLInputElement)
      .value;
    const drivers = this.shoppingCarTeam.drivers.map((driver: any) => {
      return driver.id;
    });

    if (this.checkPayment(teamName, drivers)) {
      const survey = {
        name: teamName,
        player: this.sesionService.getUser().username,
        scuderia: this.shoppingCarTeam.scudery.id,
        drivers: drivers,
      };

      this.submitPay(survey);
    }
  }

  updateUserData() {
    this.restApi
      .get_request('Players/' + this.sesionService.getUser().username, null)
      .subscribe((userData) => {
        this.sesionService.setUser(JSON.stringify(userData));
        this.router.navigateByUrl('pages/myPortal');
      });
  }

  submitPay(data: any) {
    if (this.currentAction === 'replacing') {
      this.restApi.post_request('XXXXX', data).subscribe((result) => {
        console.log(result);
        this.swalService.showSuccess(
          'Equipo Modificado',
          'El equipo fue creado con éxito'
        );

        this.updateUserData();
      });

      return;
    }
    this.restApi.post_request('PlayerTeams', data).subscribe((result) => {
      console.log(result);
      this.swalService.showSuccess(
        'Equipo creado',
        'El equipo fue creado con éxito'
      );

      this.updateUserData();
    });
  }

  /**Para asegurar que los valores de fondos se actualicen
    y que no afecten el valor de ninguna variable se modifica el contenido del html
    **/
  suscribeToMoneyCounter(): void {
    this.router.events.subscribe((val) => {
      if (val instanceof NavigationEnd)
        this.moneyCounter.innerHTML = this.sesionService.getUser().money;
    });
  }

  showPilotMaxError(): void {
    this.swalService.showError(
      'Nombre inválido',
      'Solo puede ingresar un conjunto de valores alfanuméricos no vacío'
    );
  }

  showInsuficientFoundsError(): void {
    this.swalService.showError(
      'Fondos insuficientes',
      'Actualmente no cuenta con los fondos para realizar esta compra'
    );
  }

  calcTotal(value: number): number {
    this.total += value;
    this.moneyCounter = document.getElementById('money');
    this.moneyCounter.innerHTML = parseInt(this.moneyCounter.innerHTML) - value;
    return this.total;
  }
}
