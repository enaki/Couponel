import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticationComponent } from './authentication/authentication/authentication.component';
import { TripDetailsComponent } from './trip/trip-details/trip-details.component';
import { TripListComponent } from './trip/trip-list/trip-list.component';
import { TopComponent } from './trip/top/top.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'welcome',
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  { path: 'list', component: TripListComponent },
  { path: 'create-trip', component: TripDetailsComponent },
  { path: 'topList', component: TopComponent},
  {
    path: 'notifications',
    loadChildren: () =>
      import('./notifications/notifications.module').then(
        (m) => m.NotificationsModule
      ),
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
  },
  {
    path: 'trip',
    loadChildren: () => import('./trip/trip.module').then((m) => m.TripModule),
  },
  {
    path: 'welcome',
    loadChildren: () =>
      import('./welcome/welcome.module').then(
        (m) => m.WelcomeModule
      ),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
