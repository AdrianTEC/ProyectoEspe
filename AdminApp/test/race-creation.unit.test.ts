import { AddCareerModalComponent } from '../src/app/admin/careers-control/add-career-modal/add-career-modal.component';
import { SwalService } from '../src/app/Services/swal-service.service';
import { Championship, Country, Race } from '../src/app/models/models';
import * as moment from 'moment';
import { expect } from 'chai';
import { ContentObserver } from '@angular/cdk/observers';

//                  ____________________________________
// ________________/ Instantiate Component to be tested \_________________
//                 \____________________________________/
let arg1, arg2, arg3, arg4: any;
let swal = new SwalService();
let RaceComponent = new AddCareerModalComponent(swal, arg1, arg2, arg3, arg4);

let championship = new Championship();
championship.description = 'This is a dummy championship';
championship.id = '1a2b3c';
championship.name = 'Dummy Championship';
championship.startingDate = moment().format('DD/MM/YYYY').toString();
championship.startingTime = '12:00 am';
championship.finishingDate = moment().add(7, 'days').format('DD/MM/YYYY').toString();
championship.finishingTime = '12:30 am'

RaceComponent.championships = [championship]

console.log('\n+++++ Starting Tests for Race Creation +++++')

//                        _________________________
// ______________________/ verifyFieldsAreFilled() \______________________
//                       \_________________________/

/** TEST CASE 1
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #1...')
describe('VERIFY FIELDS 1: all fields are filled correctly', () => {
    it('should return true', () => {
        let event = new Race()
        event.championshipId = 'DummyID'
        event.name = 'Dummy race';
        event.country = 'Åland Islands';
        event.finishingDate = '7/10/2043';
        event.finishingTime = '12:00 am';
        event.startingDate = '5/10/2043';
        event.startingTime = '12:30 am';
        event.trackName = 'Dummy track';
        const result = RaceComponent.verifyFieldsAreFill(event);
        expect(result).to.equal(true);
    });
});

/** TEST CASE 2
 * Expected result: 'false'.
 */
console.log('\nStarting Test Case #2...')
describe('VERIFY FIELDS 1: name is empty', () => {
    it('should return true', () => {
        let event = new Race()
        event.championshipId = 'DummyID'
        event.name = '';
        event.country = 'Åland Islands';
        event.finishingDate = '7/10/2043';
        event.finishingTime = '12:00 am';
        event.startingDate = '5/10/2043';
        event.startingTime = '12:30 am';
        event.trackName = 'Dummy track';
        const result = RaceComponent.verifyFieldsAreFill(event);
        expect(result).to.equal(false);
    });
});

/** TEST CASE 3
 * Expected result: 'false'.
 */
console.log('\nStarting Test Case #3...')
describe('VERIFY FIELDS 3: championshipID is empty', () => {
    it('should return true', () => {
        let event = new Race()
        event.championshipId = ''
        event.name = 'Dummy race';
        event.country = 'Åland Islands';
        event.finishingDate = '7/10/2043';
        event.finishingTime = '12:00 am';
        event.startingDate = '5/10/2043';
        event.startingTime = '12:30 am';
        event.trackName = 'Dummy track';
        const result = RaceComponent.verifyFieldsAreFill(event);
        expect(result).to.equal(false);
    });
});

/** TEST CASE 4
 * Expected result: 'false'.
 */
console.log('\nStarting Test Case #4...')
describe('VERIFY FIELDS 4: times are Invalid date, dates are empty', () => {
    it('should return true', () => {
        let event = new Race()
        event.championshipId = 'DummyID'
        event.name = 'Dummy race';
        event.country = 'Åland Islands';
        event.finishingDate = '';
        event.finishingTime = 'Invalid date';
        event.startingDate = '';
        event.startingTime = 'Invalid date';
        event.trackName = 'Dummy track';
        const result = RaceComponent.verifyFieldsAreFill(event);
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
        let tomorrow = moment().add(1, 'days').format('DD/MM/YYYY')
        let dayAfterTomorrow = moment().add(2, 'days').format('DD/MM/YYYY')

        let event = new Race()
        event.startingDate = tomorrow;
        event.startingTime = '12:30 am';
        event.finishingDate = dayAfterTomorrow;
        event.finishingTime = '12:00 am';
        const result = RaceComponent.verifyDateisAfterToday(event);
        expect(result).to.equal(true);
    });
});

 /** TEST CASE 6
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #6...')
describe('VERIFY DATE IS AFTER TODAY 2: starting and finishing dates are today', () => {
    it('should return false', () => {
        let today = moment().format('DD/MM/YYYY').toString();

        let event = new Race()
        event.startingDate = today;
        event.startingTime = '12:30 am';
        event.finishingDate = today;
        event.finishingTime = '12:00 am';
        const result = RaceComponent.verifyDateisAfterToday(event);
        expect(result).to.equal(false);
    });
});

/** TEST CASE 7
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #7...')
describe('VERIFY DATE IS AFTER TODAY 3: starting date is yesterday and finishing date is today', () => {
    it('should return false', () => {
        let yesterday = moment().subtract(1, 'days').format('DD/MM/YYYY').toString();
        let today = moment().format('DD/MM/YYYY').toString();

        let event = new Race()
        event.startingDate = yesterday;
        event.startingTime = '12:30 am';
        event.finishingDate = today;
        event.finishingTime = '12:00 am';
        const result = RaceComponent.verifyDateisAfterToday(event);
        expect(result).to.equal(false);
    });
});

//                    _________________________________
// __________________/ verifyRaceInChampionshipRange() \__________________
//                   \_________________________________/

/** TEST CASE 8
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #8...')
describe('VERIFY RACE IN CHAMPIONSHIP RANGE 1: race starts tomorrow, ends the following day', () => {
    it('should return true', () => {
        let tomorrow = moment().add(1, 'days').format('DD/MM/YYYY').toString();
        let dayAfterTomorrow = moment().add(2, 'days').format('DD/MM/YYYY').toString();

        let event = new Race()
        event.championshipId = '1a2b3c';
        event.startingDate = tomorrow;
        event.startingTime = '12:30 am';
        event.finishingDate = dayAfterTomorrow;
        event.finishingTime = '12:00 am';
        const result = RaceComponent.verifyRaceInChampionshipRange(event);
        expect(result).to.equal(true);
    });
});

/** TEST CASE 9
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #9...')
describe('VERIFY RACE IN CHAMPIONSHIP RANGE 2: race starts in a month, ends the following day', () => {
    it('should return false', () => {
        let nextMonth = moment().add(30, 'days').format('DD/MM/YYYY').toString();
        let dayAfterStart = moment().add(31, 'days').format('DD/MM/YYYY').toString();
    
        let event = new Race()
        event.championshipId = '1a2b3c';
        event.startingDate = nextMonth;
        event.startingTime = '12:30 am';
        event.finishingDate = dayAfterStart;
        event.finishingTime = '12:00 am';
        const result = RaceComponent.verifyRaceInChampionshipRange(event);
        expect(result).to.equal(false);
    });
 });

 /** TEST CASE 10
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #10...')
describe('VERIFY RACE IN CHAMPIONSHIP RANGE 3: race starts yesterday, ends today', () => {
      it('should return false', () => {
        let yesterday = moment().subtract(1, 'days').format('DD/MM/YYYY').toString();
        let today = moment().format('DD/MM/YYYY').toString();
  
        let event = new Race()
        event.championshipId = '1a2b3c';
        event.startingDate = yesterday;
        event.startingTime = '12:30 am';
        event.finishingDate = today;
        event.finishingTime = '12:00 am';
        const result = RaceComponent.verifyRaceInChampionshipRange(event);
        expect(result).to.equal(false);
    });
});

console.log('\n----- Tests for Race Creation Finished -----\n')