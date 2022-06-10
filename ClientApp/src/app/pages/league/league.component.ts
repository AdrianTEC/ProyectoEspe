import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CheckerService } from 'src/app/Services/checker.service';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SesionService } from 'src/app/Services/sesion-service.service';
import { SwalService } from 'src/app/Services/swal-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-league',
  templateUrl: './league.component.html',
  styleUrls: ['./league.component.css'],
})
export class LeagueComponent implements OnInit {
  constructor(
    private checker: CheckerService,
    private swal: SwalService,
    private sesion: SesionService,
    private restApi: RestApiServiceService,
    private router: Router
  ) {}
  league: any = null;
  myTeams = ['asd', 'abdddd'];
  ngOnInit(): void {
    this.sesion.refreshUser();

    this.getLeague();
  }
  getLeague() {
    const leagueName: string = this.sesion.getUser().privateLeague;
    if (leagueName === '' || leagueName.length == 0) {
      this.league = null;
      return;
    }
    console.log(leagueName);

    this.restApi
      .get_request('PrivateLeague/' + leagueName, null)
      .subscribe((result) => {
        console.log(result);

        this.league = result;
      });
  }
  createNewLeague(): void {
    Swal.fire({
      title: 'Inserte el nombre de la liga',
      input: 'text',
      showCancelButton: true,
      confirmButtonText: 'Crear',
    }).then((result) => {
      if (!result.isConfirmed) return;
      if (!this.checker.verifyName(result.value, 5, 30, true)) {
        this.swal.showError(
          'Nombre inválido',
          'El nombre de la liga debe ser un valor alfa numérico no vacío'
        );
        return;
      }

      const data = {
        leagueCreatorUsername: this.sesion.getUser().username,
        name: result.value,
      };
      this.restApi.post_request('PrivateLeague', data).subscribe(
        (response) => {
          this.swal.showSuccess(
            'Liga Creada',
            'Tu liga se ha creado exitosamente'
          );
          document.location.reload();
        },
        (error) => {
          this.swal.showError(
            'Error al crear Liga',
            'Ha ocurrido un error al crear esta liga'
          );
        }
      );
    });
  }

  joinToLeague(): void {
    Swal.fire({
      title: 'Inserte el código de acceso',
      input: 'text',
      showCancelButton: true,
      confirmButtonText: 'Crear',
    }).then((result) => {
      if (!result.isConfirmed || result.value < 4 || result.value === '') {
        this.swal.showError(
          'Código no válido',
          'Solicite un código de acceso válido'
        );
        return;
      }
      const data = {
        invitationCode: result.value,
        playerUsername: this.sesion.getUser().username,
      };
      this.restApi.post_request('PrivateLeague/joinRequest', data).subscribe(
        (result) => {
          this.swal.showSuccess(
            'Solicitud envidad',
            'Un administrador de esta liga verificará tu solicitud'
          );
        },
        (error) => {
          this.swal.showError(
            'Código no válido',
            'El código ingresado no pertenece a ninguna liga privada'
          );
        }
      );
    });
  }
  teamIsOfUser(teamName: string): boolean {
    return this.myTeams.includes(teamName);
  }

  openProfile(userName: string): void {
    this.router.navigate(['pages/profile'], {
      queryParams: { userName: userName },
    });
  }
}
