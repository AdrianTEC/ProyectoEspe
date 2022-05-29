import { AddChampionshipModalComponent } from '../src/app/admin/championship-control/add-championship-modal/add-championship-modal.component';
import { SwalService } from '../src/app/Services/swal-service.service';
import { Championship } from '../src/app/models/models';
import * as moment from 'moment';
import { expect } from 'chai';
import { ContentObserver } from '@angular/cdk/observers';

//                  ____________________________________
// ________________/ Instantiate Component to be tested \_________________
//                 \____________________________________/
let arg1, arg2, arg3: any;
let swal = new SwalService();
let ChampionshipComponent = new AddChampionshipModalComponent(swal, arg1, arg2, arg3);

console.log('\n+++++ Starting Tests for Championship Creation +++++')

//                        _________________________
// ______________________/ verifyFieldsAreFilled() \______________________
//                       \_________________________/

/** TEST CASE 1
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #1...')
describe('VERIFY FIELDS 1: all fields are filled correctly', () => {
    it('should return true', () => {
        let event = new Championship()
        event.name = 'Dummy championship';
        event.startingDate = '29/05/2023';
        event.startingTime = '12:00 am';
        event.finishingDate = '30/05/2023';
        event.finishingTime = '12:30 am';
        const result = ChampionshipComponent.verifyFieldsAreFill(event);
        expect(result).to.equal(true);
    });
});

/** TEST CASE 2
 * Expected result: 'false'.
 */
console.log('\nStarting Test Case #2...')
describe('VERIFY FIELDS 2: name is empty', () => {
    it('should return false', () => {
        let event = new Championship()
        event.name = '';
        event.startingDate = '29/05/2023';
        event.startingTime = '12:00 am';
        event.finishingDate = '30/05/2023';
        event.finishingTime = '12:30 am';
        const result = ChampionshipComponent.verifyFieldsAreFill(event);
        expect(result).to.equal(false);
    });
});

/** TEST CASE 3
 * Expected result: 'false'.
 */
console.log('\nStarting Test Case #3...')
describe('VERIFY FIELDS 3: dates are Invalid date', () => {
    it('should return false', () => {
        let event = new Championship()
        event.name = 'Dummy championship';
        event.startingDate = '29/05/2023';
        event.startingTime = 'Invalid date';
        event.finishingDate = '30/05/2023';
        event.finishingTime = 'Invalid date';
        const result = ChampionshipComponent.verifyFieldsAreFill(event);
        expect(result).to.equal(false);
    });
});

/** TEST CASE 4
 * Expected result: 'false'.
 */
console.log('\nStarting Test Case #4...')
describe('VERIFY FIELDS 4: all fields are empty', () => {
    it('should return false', () => {
        let event = new Championship()
        event.name = '';
        event.startingDate = '';
        event.startingTime = '';
        event.finishingDate = '';
        event.finishingTime = '';
        const result = ChampionshipComponent.verifyFieldsAreFill(event);
        expect(result).to.equal(false);
    });
});

//                        __________________________
// ______________________/ verifyDateisAfterToday() \_____________________
//                       \__________________________/

/** TEST CASE 5
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #5...')
describe('VERIFY DATE IS AFTER TODAY 1: starting date is tomorrow, finishing date is the following day', () => {
    it('should return true', () => {
        let tomorrow = moment().add(1, 'days').format('DD/MM/YYYY').toString();
        let dayAfterTomorrow = moment().add(2, 'days').format('DD/MM/YYYY').toString();

        let event = new Championship()
        event.startingDate = tomorrow;
        event.startingTime = '12:00 am';
        event.finishingDate = dayAfterTomorrow;
        event.finishingTime = '12:30 am';
        const result = ChampionshipComponent.verifyDateisAfterToday(event);
        expect(result).to.equal(true);
    });
});

/** TEST CASE 6
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #6...')
describe('VERIFY DATE IS AFTER TODAY 2: starting and finishing dates are today', () => {
    it('should return false', () => {
        let today = moment().format('DD/MM/YYYY').toString();

        let event = new Championship()
        event.startingDate = today;
        event.startingTime = '12:00 am';
        event.finishingDate = today;
        event.finishingTime = '12:30 am';
        const result = ChampionshipComponent.verifyDateisAfterToday(event);
        expect(result).to.equal(false);
    });
});

/** TEST CASE 7
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #7...')
describe('VERIFY DATE IS AFTER TODAY 3: starting date is yesterday and finishing date is today', () => {
    it('should return false', () => {
        let yesterday = moment().subtract(1, 'days').format('DD/MM/YYYY').toString();
        let today = moment().format('DD/MM/YYYY').toString();

        let event = new Championship()
        event.startingDate = yesterday;
        event.startingTime = '12:00 am';
        event.finishingDate = today;
        event.finishingTime = '12:30 am';
        const result = ChampionshipComponent.verifyDateisAfterToday(event);
        expect(result).to.equal(false);
    });
});

console.log('\n----- Tests for Championship Creation Finished -----\n')