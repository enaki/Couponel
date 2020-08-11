import { CommonModule } from '@angular/common';
import {NgModule} from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

import { HeaderComponent } from './header/header.component';
import { TileComponent } from './tile/tile.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [TileComponent, HeaderComponent, FooterComponent],
  imports: [CommonModule, MatIconModule],
  exports: [TileComponent, HeaderComponent, FooterComponent],
})
export class SharedModule {
  constructor(){
  }
}
