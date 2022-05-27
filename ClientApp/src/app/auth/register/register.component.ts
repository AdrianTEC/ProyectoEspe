import { Component, OnInit } from '@angular/core';
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
    private backend: RestApiServiceService
  ) {}
  rangosEdad: string[] = ['18-25', '25-35', '35-50', '50+'];
  countries: any = [];

  ngOnInit(): void {
    this.countries = this.countryService.getCountries();
    console.log(this.countries);
  }
  isAlphaNumeric(value: string) {
    var code, i, len;

    for (i = 0, len = value.length; i < len; i++) {
      code = value.charCodeAt(i);
      if (
        !(code > 47 && code < 58) && // numeric (0-9)
        !(code > 64 && code < 91) && // upper alpha (A-Z)
        !(code > 96 && code < 123)
      ) {
        // lower alpha (a-z)
        return false;
      }
    }
    return true;
  }

  verifyName(
    name: string,
    minimum: number = 1,
    maximum: number = 100,
    isAlphaNumeric: boolean = false
  ): boolean {
    const isEmpty = name === '' || !name;

    const alphaNumeric: boolean = !isAlphaNumeric || this.isAlphaNumeric(name);
    const lengh = name.length >= minimum && name.length < maximum;

    return alphaNumeric && !isEmpty && lengh;
  }

  checkUpperLowerCaseNumber(value: string) {
    let result = { hasUpper: false, hasLower: false, hasNumber: false };
    var i = 0;
    var character = '';
    while (i <= value.length) {
      character = value.charAt(i);
      if (!isNaN(character as any)) result.hasNumber = true;
      if (character == character.toUpperCase()) result.hasUpper = true;

      if (character == character.toLowerCase()) result.hasLower = true;

      i++;
    }
    return result;
  }
  verifyPassword(password: string) {
    const textValid = this.verifyName(password, 10, 16, true);
    const upperLowerAndNumber = this.checkUpperLowerCaseNumber(password);

    const result =
      textValid &&
      upperLowerAndNumber.hasLower &&
      upperLowerAndNumber.hasNumber &&
      upperLowerAndNumber.hasUpper;

    return result;
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
    const nameCheck = this.verifyName(data.name, 5, 30, false);
    const usernameCheck = this.verifyName(data.username);
    const passwordIsValid = this.verifyPassword(data.password);
    const mailIsValid = true || this.validateEmail(data.mail);
    const othersFieldsFilled = this.validateFullValues(data);
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
