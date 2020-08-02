import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-tile',
  templateUrl: './tile.component.html',
  styleUrls: ['./tile.component.scss'],
})
export class TileComponent implements OnInit {
  @Input() public label: string = '';
  @Input() public icon: string = '';
  @Input() public background: string = '';

  public hasPicture: boolean;

  ngOnInit(): void {
    if (this.background) {
      this.background = "url('" + this.background + "')";
    } else {
      this.background = "linear-gradient(to bottom right, #54c4a8, #8bf3d9)";
    }


  }

}
