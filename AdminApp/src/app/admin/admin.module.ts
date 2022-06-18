import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { ChampionshipControlComponent } from './championship-control/championship-control.component';
import { CareersControlComponent } from './careers-control/careers-control.component';
import { AdminComponent } from './admin.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminNavBarComponent } from './shared/admin-nav-bar/admin-nav-bar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { AddChampionshipModalComponent } from './championship-control/add-championship-modal/add-championship-modal.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { AddCareerModalComponent } from './careers-control/add-career-modal/add-career-modal.component';
import { MatSelectModule } from '@angular/material/select';
import { TopLeagueModalComponent } from './championship-control/top-league-modal/top-league-modal.component';
import { ResultsComponent } from './results/results.component';
import { MatTableModule } from '@angular/material/table';
@NgModule({
  declarations: [
    ChampionshipControlComponent,
    CareersControlComponent,
    AdminComponent,
    AdminHomeComponent,
    AdminNavBarComponent,
    AddChampionshipModalComponent,
    AddCareerModalComponent,
    TopLeagueModalComponent,
    ResultsComponent,
  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatTableModule,
    MatSelectModule,
    MatNativeDateModule,
    AdminRoutingModule,
    MatIconModule,
    MatIconModule,
    MatDialogModule,
  ],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'en-GB' }],
})
export class AdminModule {}
