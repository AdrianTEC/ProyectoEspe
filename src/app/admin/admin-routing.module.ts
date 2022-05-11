import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminComponent } from './admin.component';
import { CareersControlComponent } from './careers-control/careers-control.component';
import { ChampionshipControlComponent } from './championship-control/championship-control.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    canActivateChild: [
      /*AuthGuard*/
    ],
    children: [
      {
        path: 'home',
        component: AdminHomeComponent,
      },
      {
        path: 'careers',
        component: CareersControlComponent,
      },
      {
        path: 'championship',
        component: ChampionshipControlComponent,
      },

      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: '**', redirectTo: 'home' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
