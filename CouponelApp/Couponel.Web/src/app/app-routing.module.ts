import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VoucherListComponent } from './voucher/voucher-list/voucher-list.component';
import { TopComponent } from './voucher/top/top.component';
import { ProfileInfoComponent } from './profile/profile-info/profile-info.component';

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
  { path: 'list', component: VoucherListComponent },
  { path: 'top-list', component: TopComponent},
  { path: 'profile-info', component: ProfileInfoComponent},
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
    path: 'voucher',
    loadChildren: () => import('./voucher/voucher.module').then((m) => m.VoucherModule),
  },
  {
    path: 'welcome',
    loadChildren: () =>
      import('./welcome/welcome.module').then(
        (m) => m.WelcomeModule
      ),
  },
  {
    path: 'profile',
    loadChildren: () =>
      import('./profile/profile.module').then((m) => m.ProfileModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
