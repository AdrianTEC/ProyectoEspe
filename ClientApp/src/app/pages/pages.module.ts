import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { StoreComponent } from './store/store.component';
import { MyPortalComponent } from './my-portal/my-portal.component';
import { NavBarComponent } from '../shared/nav-bar/nav-bar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    PagesComponent,
    StoreComponent,
    MyPortalComponent,
    NavBarComponent,
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    MatIconModule,
    MatNativeDateModule,
  ],
})
export class PagesModule {}
