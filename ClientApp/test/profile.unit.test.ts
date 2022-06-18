import { ProfileComponent } from '../src/app/pages/profile/profile.component';
import { expect } from 'chai';

//                  ____________________________________
// ________________/ Instantiate Component to be tested \_________________
//                 \____________________________________/
let arg1, arg2, arg3, arg4: any;
let ProfileComp = new ProfileComponent(arg1, arg2, arg3, arg4);
const TOP_PLAYERS = [{teamname: 'Best Team', score: 20}, {teamname: 'Worst Team', score: 10}, {teamname: 'Middle Team', score: 15}]

console.log('\n+++++ Starting Tests for Profile +++++')

//                                ___________
// ______________________________/ sortTop() \____________________________
//                               \___________/

/** TEST CASE 1
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #1...')
describe('SORT TOP 1: sorts 3 unordered values', () => {
    it('should return true', () => {
        ProfileComp.top = TOP_PLAYERS
        ProfileComp.sortTop()
        let best = ProfileComp.top[0].score == 20;
        let middle = ProfileComp.top[1].score == 15;
        let worst = ProfileComp.top[2].score == 10
        expect(best && middle && worst).to.equal(true);
    });
});

/** TEST CASE 2
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #2...')
describe('SORT TOP 2: sorts array two times', () => {
    it('should return true', () => {
        ProfileComp.top = TOP_PLAYERS
        ProfileComp.sortTop()
        ProfileComp.sortTop()
        let best = ProfileComp.top[0].score == 20;
        let middle = ProfileComp.top[1].score == 15;
        let worst = ProfileComp.top[2].score == 10
        expect(best && middle && worst).to.equal(true);
    });
});

console.log('\n----- Tests for Profile Finished -----\n')