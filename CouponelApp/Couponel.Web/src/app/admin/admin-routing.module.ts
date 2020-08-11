import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {StatisticsComponent} from './statistics/statistics.component';

const routes: Routes = [
  {
    path: 'statistics',
    pathMatch: 'full',
    component: StatisticsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule { }
