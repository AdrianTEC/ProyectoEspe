import { StoreComponent } from '../src/app/pages/store/store.component';
import { SwalService } from '../src/app/Services/swal-service.service';
import { expect } from 'chai';

//                  ____________________________________
// ________________/ Instantiate Component to be tested \_________________
//                 \____________________________________/
let arg1, arg2, arg4, arg5, arg6: any;
let swal = new SwalService();
let StoreComp = new StoreComponent(arg1, arg2, swal, arg4, arg5, arg6);

//                             ________________
// ___________________________/ checkPayment() \__________________________
//                            \________________/

/** TEST CASE 1
 * Expected result: 'true'
 */