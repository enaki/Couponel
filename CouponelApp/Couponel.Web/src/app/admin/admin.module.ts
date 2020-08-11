import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatisticsComponent } from './statistics/statistics.component';
import {AdminRoutingModule} from './admin-routing.module';

@NgModule({
  declarations: [StatisticsComponent],
  imports: [
    CommonModule, AdminRoutingModule
  ],
  exports: [StatisticsComponent],
})
export class AdminModule { }
