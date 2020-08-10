import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticationComponent } from './authentication/authentication/authentication.component';
import { VoucherDetailsComponent } from './voucher/voucher-details/voucher-details.component';
import { VoucherListComponent } from './voucher/voucher-list/voucher-list.component';
import { TopComponent } from './voucher/top/top.component';
import { ProfileInfoComponent } from './profile/profile-info/profile-info.component';
import { SavedVouchersComponent } from './profile/saved-vouchers/saved-vouchers.component';
import {RedeemedVoucherComponent} from './voucher/redeemed-voucher/redeemed-voucher.component';
import {RedeemedVoucherDetailsComponent} from './voucher/redeemed-voucher-details/redeemed-voucher-details.component';
import {VoucherCreateComponent} from "./voucher/voucher-create/voucher-create.component";

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
  { path: 'create', component: VoucherCreateComponent},
  { path: 'top-list', component: TopComponent},
  { path: 'profile-info', component: ProfileInfoComponent},
  { path: 'saved-vouchers', component: SavedVouchersComponent},
  { path: 'my-vouchers', component: RedeemedVoucherComponent},
  { path: 'my-vouchers/details/:id', component: RedeemedVoucherDetailsComponent},
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
