import { LeagueComponent } from '../src/app/pages/league/league.component';
import { SwalService } from '../src/app/Services/swal-service.service';
import { expect } from 'chai';

//                  ____________________________________
// ________________/ Instantiate Component to be tested \_________________
//                 \____________________________________/
let arg1, arg3, arg4, arg5: any;
let swal = new SwalService();
let LeagueComp = new LeagueComponent(arg1, swal, arg3, arg4, arg5);

console.log('\n+++++ Starting Tests for League +++++')

//                            ________________
// __________________________/ teamIsOfUser() \___________________________
//                           \________________/

/** TEST CASE 1
 * Expected result: 'true'
 */
console.log('\nStarting Test Case #1...')
describe('TEAM IS OF USER 1: team name is included in myTeams', () => {
    it('should return true', () => {
    LeagueComp.myTeams = ['Team1']
    const valid = LeagueComp.teamIsOfUser('Team1');
    expect(valid).to.equal(true);
    });
});

/** TEST CASE 2
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #2...')
describe('TEAM IS OF USER 2: myTeams is empty', () => {
    it('should return false', () => {
    LeagueComp.myTeams = ['']
    const valid = LeagueComp.teamIsOfUser('Team1');
    expect(valid).to.equal(false);
    });
});

/** TEST CASE 3
 * Expected result: 'false'
 */
console.log('\nStarting Test Case #3...')
describe('TEAM IS OF USER 3: team not included in myTeams', () => {
    it('should return false', () => {
    LeagueComp.myTeams = ['Team1', 'Team2', 'Team3']
    const valid = LeagueComp.teamIsOfUser('TeamA');
    expect(valid).to.equal(false);
    });
});

console.log('\n----- Tests for League Finished -----\n')