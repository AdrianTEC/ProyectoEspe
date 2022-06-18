import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeagueComponent } from './league/league.component';
import { MyPortalComponent } from './my-portal/my-portal.component';
import { PagesComponent } from './pages.component';
import { ProfileComponent } from './profile/profile.component';
import { StoreComponent } from './store/store.component';

const routes: Routes = [
  {
    path: '',
    component: PagesComponent,
    //canActivateChild: [SecureInnerPagesGuard],
    children: [
      {
        path: 'xfiaPortal',
        component: MyPortalComponent,
      },
      {
        path: 'store',
        component: StoreComponent,
      },
      {
        path: 'profile',
        component: ProfileComponent,
      },
      {
        path: 'league',
        component: LeagueComponent,
      },

      {
        path: '',
        redirectTo: 'xfiaPortal',
        pathMatch: 'full',
      },
      {
        path: '**',
        redirectTo: 'xfiaPortal',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
