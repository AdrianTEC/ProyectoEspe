import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { StoreComponent } from './store/store.component';
import { MyPortalComponent } from './my-portal/my-portal.component';
import { NavBarComponent } from '../shared/nav-bar/nav-bar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatNativeDateModule } from '@angular/material/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatSnackBarModule } from '@angular/material/snack-bar';
@NgModule({
  declarations: [
    PagesComponent,
    StoreComponent,
    MyPortalComponent,
    NavBarComponent,
  ],
  imports: [
    CommonModule,
    MatSnackBarModule,
    PagesRoutingModule,
    MatIconModule,
    MatMenuModule,
    MatNativeDateModule,
  ],
})
export class PagesModule {}
