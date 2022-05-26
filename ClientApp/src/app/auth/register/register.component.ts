import { Component, OnInit } from '@angular/core';
import { CountryService } from 'src/app/Services/country-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private countryService: CountryService) {}
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

  verifyName(name: string, sizeRestriction: number = 100): boolean {
    const isEmpty = name === '' || !name;
    const alphaNumeric: boolean = this.isAlphaNumeric(name);
    const lengh = name.length <= sizeRestriction;

    return alphaNumeric && !isEmpty && lengh;
  }

  checkUpperLowerCaseNumber() {
    var strings = 'this iS a TeSt 523 Now!';
    var i = 0;
    var character = '';
    while (i <= strings.length) {
      character = strings.charAt(i);
      if (!isNaN(character * 1)) {
        alert('character is numeric');
      } else {
        if (character == character.toUpperCase()) {
          alert('upper case true');
        }
        if (character == character.toLowerCase()) {
          alert('lower case true');
        }
      }
      i++;
    }
  }
  verifyPassword(password: string) {
    const textValid = this.verifyName(password);
    const hasUpperCase;
  }
  verifyData(data: any) {
    const nameCheck = this.verifyName(data.name);
    const usernameCheck = this.verifyName(data.username);

    return nameCheck && usernameCheck;
  }
  register(data: any) {
    console.log(data);
  }
}
