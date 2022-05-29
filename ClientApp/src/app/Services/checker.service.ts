import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CheckerService {
  constructor() {}

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
    name = name.replace(/\s/g, '');
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

  checkForDuplicates(array: any[]) {
    return new Set(array).size !== array.length;
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
}
