import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SesionService } from 'src/app/Services/sesion-service.service';
import { SwalService } from 'src/app/Services/swal-service.service';
import { Md5 } from 'ts-md5/dist/md5';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    private router: Router,
    private backend: RestApiServiceService,
    private sesionService: SesionService,
    private swal: SwalService
  ) {}

  ngOnInit(): void {}

  login(username: string, password: string): void {
    password = Md5.hashStr(password);

    const data = { username: username, password: password };

    this.backend.post_request('Login', data).subscribe(
      (userAuth: any) => {
        console.log(userAuth);

        if (!userAuth.isPlayer) {
          this.showNoExistingAccount();

          return;
        }
        this.backend
          .get_request('Players/' + username, null)
          .subscribe((userData) => {
            if (!userData.confirmedAccount) {
              this.swal.showError(
                'Usuario no confirmado',
                'No se ha activado este usuario, por lo que debe realizarse la confirmación de cuenta'
              );
              return;
            }
            this.sesionService.setUser(JSON.stringify(userData));

            this.router.navigateByUrl('/pages');
          });
      },
      (error) => {
        this.showNoExistingAccount();
      }
    );
  }

  register(): void {
    this.router.navigateByUrl('/auth/register');
  }

  showNoExistingAccount() {
    this.swal.showError(
      'Usuario o Contraseña incorrecta',
      'No existe un usuario registrado con dicha contraseña'
    );
  }
}
