import { Component, OnInit } from '@angular/core';
import { CheckerService } from 'src/app/Services/checker.service';
import { CountryService } from 'src/app/Services/country-service.service';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SwalService } from 'src/app/Services/swal-service.service';
import { Md5 } from 'ts-md5/dist/md5';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(
    private countryService: CountryService,
    private swal: SwalService,
    private backend: RestApiServiceService,
    private checker: CheckerService
  ) {}
  rangosEdad: string[] = ['18-25', '25-35', '35-50', '50+'];
  countries: any = [];

  ngOnInit(): void {
    this.countries = this.countryService.getCountries();
    console.log(this.countries);
  }

  validateEmail(email: string): boolean {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email)) {
      return true;
    }
    return false;
  }

  validateFullValues(data: any): boolean {
    const country = data.country != '';
    const ageRange = data.ageRange != '';
    const name = data.name != '';
    const username = data.username != '';
    const email = data.email != '';
    const password = data.password != '';
    return country && ageRange && name && username && email && password;
  }

  writeErrorMessage(
    nameCheck: boolean,
    usernameCheck: boolean,
    passwordIsValid: boolean,
    mailIsValid: boolean,
    allFieldsFilled: boolean
  ) {
    let message =
      'Se detectaron los siguientes errores con el formulario de registro: <br>';
    if (!nameCheck)
      message +=
        ' El nombre no es válido, debe ser un conjunto alfa numerico no vacio<br>';
    if (!usernameCheck)
      message +=
        ' El nombre de usuario no es válido, debe ser un conjunto alfa numerico no vacio<br>';
    if (!passwordIsValid)
      message +=
        ' La contraseña no es  válida, debe ser un conjunto alfa numerico con mínimo una mayúscula, una minúscula y entre 10 y 16 dígitos<br>';
    if (!mailIsValid) message += ' El correo ingresado no es válido<br>';
    if (!allFieldsFilled) message = ' Por favor llene todos los espacios<br>';

    if (!nameCheck || !usernameCheck || !passwordIsValid || !mailIsValid)
      this.swal.showErrorHTML('Datos ingresados Incorrectos', message);
  }

  verifyData(data: any) {
    const nameCheck = this.checker.verifyName(data.name, 5, 30, false);
    const usernameCheck = this.checker.verifyName(data.username);
    const passwordIsValid = this.checker.verifyPassword(data.password);
    const mailIsValid = true || this.checker.validateEmail(data.mail);
    const othersFieldsFilled = this.checker.validateFullValues(data);
    this.writeErrorMessage(
      nameCheck,
      usernameCheck,
      passwordIsValid,
      mailIsValid,
      othersFieldsFilled
    );
    return nameCheck && usernameCheck && passwordIsValid && mailIsValid;
  }

  /**
   * 
     "username": "string",
  "password": "string",
  "name": "string",
  "lastName": "string",
  "email": "string",
  "country": "string",
  "ageRange": "string"
   * 
   * 
    country: "Cambodia"
    email: "asdas"
    name: "ss"
    lastName: "string"
    password: "asd"
    username: "adriantec2019@gmail.com"
   * 
   */
  register(data: any) {
    if (this.verifyData(data)) this.submitRegister(data);
  }

  submitRegister(data: any) {
    this.swal.showSuccess(
      'Registro exitoso',
      'Se ha enviado el link de verificacion  a tu correo electronico'
    );
    data.password = Md5.hashStr(data.password);

    console.log(data);
    this.backend.post_request('Players', data).subscribe((result) => {});
  }
}
