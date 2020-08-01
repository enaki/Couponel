import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { TripDetailsComponent } from './trip-details/trip-details.component';
import { TripListComponent } from './trip-list/trip-list.component';
import { TripRoutingModule } from './trip-routing.module';
import { TopComponent } from './top/top.component';

@NgModule({
  declarations: [TripDetailsComponent, TripListComponent, TopComponent],
  imports: [CommonModule, TripRoutingModule, FormsModule, ReactiveFormsModule, SharedModule],
  exports: [TripDetailsComponent, TripListComponent],
})
export class TripModule { }
