import { CommonModule } from '@angular/common';
import {NgModule} from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

import { HeaderComponent } from './header/header.component';
import { TileComponent } from './tile/tile.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import {Subject} from 'rxjs';

@NgModule({
  declarations: [TileComponent, HeaderComponent],
  imports: [CommonModule, MatIconModule],
  exports: [TileComponent, HeaderComponent],
})
export class SharedModule {
  constructor(){
  }
}
