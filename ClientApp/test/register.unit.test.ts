import { RegisterComponent } from '../src/app/auth/register/register.component';
import { SwalService } from '../src/app/Services/swal-service.service';
import { expect } from 'chai';

//                  ____________________________________
// ________________/ Instantiate Component to be tested \_________________
//                 \____________________________________/
let arg1, arg3, arg4: any;
let swal = new SwalService();
let RegisterComp = new RegisterComponent(arg1, swal, arg3, arg4);

console.log('\n+++++ Starting Tests for Register +++++')

//                            _________________
// __________________________/ validateEmail() \__________________________
//                           \_________________/

/** TEST CASE 1
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #1...')
describe('VALIDATE EMAIL 1: email has correct format', () => {
    it('should return true', () => {
        const valid = RegisterComp.validateEmail('sample_email@gmail.com');
        expect(valid).to.equal(true);
    });
});

/** TEST CASE 2
 * Expected result: 'true'
 */
 console.log('\nStarting Test Case #2...')
 describe('VALIDATE EMAIL 2: email has any mail server', () => {
     it('should return true', () => {
         const valid = RegisterComp.validateEmail('sample_email@anything.com');
         expect(valid).to.equal(true);
     });
 });

 /** TEST CASE 3
 * Expected result: 'true'
 */
  console.log('\nStarting Test Case #3...')
  describe('VALIDATE EMAIL 3: email has .es domain', () => {
      it('should return true', () => {
          const valid = RegisterComp.validateEmail('sample_email@gmail.es');
          expect(valid).to.equal(true);
      });
  });

 /** TEST CASE 4
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #4...')
describe('VALIDATE EMAIL 4: email field is empty', () => {
    it('should return false', () => {
        const valid = RegisterComp.validateEmail('');
        expect(valid).to.equal(false);
    });
});

 /** TEST CASE 5
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #5...')
describe('VALIDATE EMAIL 5: email doesnt have @ symbol', () => {
    it('should return false', () => {
        const valid = RegisterComp.validateEmail('sample_emailgmail.com');
        expect(valid).to.equal(false);
    });
});

 /** TEST CASE 6
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #6...')
describe('VALIDATE EMAIL 6: email doesnt have domain', () => {
    it('should return false', () => {
        const valid = RegisterComp.validateEmail('sample_email@gmail');
        expect(valid).to.equal(false);
    });
});

 /** TEST CASE 7
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #7...')
describe('VALIDATE EMAIL 7: email doesnt have username', () => {
    it('should return false', () => {
        const valid = RegisterComp.validateEmail('@gmail.com');
        expect(valid).to.equal(false);
    });
});


//                         ______________________
// _______________________/ validateFullValues() \________________________
//                        \______________________/

/** TEST CASE 1
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #1...')
describe('VALIDATE FILLED VALUES 1: all fields are filled', () => {
    it('should return true', () => {
        const data = {
        country: 'Costa Rica',
        ageRange: '18-25',
        name: 'John Doe',
        username: 'JonnyDoe',
        email: 'john_doe@gmail.com',
        password: 'AbCd102938'
        }
        const valid = RegisterComp.validateFullValues(data);
        expect(valid).to.equal(true);
    });
});

/** TEST CASE 2
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #2...')
describe('VALIDATE FILLED VALUES 2: email not filled', () => {
    it('should return false', () => {
        const data = {
        country: 'Costa Rica',
        ageRange: '18-25',
        name: 'John Doe',
        username: 'JonnyDoe',
        email: '',
        password: 'AbCd102938'
        }
        const valid = RegisterComp.validateFullValues(data);
        expect(valid).to.equal(false);
    });
});

/** TEST CASE 3
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #3...')
describe('VALIDATE FILLED VALUES 3: some fields empty', () => {
    it('should return false', () => {
        const data = {
        country: '',
        ageRange: '18-25',
        name: 'John Doe',
        username: '',
        email: 'john_doe@gmail.com',
        password: ''
        }
        const valid = RegisterComp.validateFullValues(data);
        expect(valid).to.equal(false);
    });
});

/** TEST CASE 4
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #4...')
describe('VALIDATE FILLED VALUES 4: all fields empty', () => {
    it('should return false', () => {
        const data = {
        country: '',
        ageRange: '',
        name: '',
        username: '',
        email: '',
        password: ''
        }
        const valid = RegisterComp.validateFullValues(data);
        expect(valid).to.equal(false);
    });
});


console.log('\n----- Tests for Register Finished -----\n')