import { Component, Input, OnInit } from "@angular/core";
import { RubiksBoxDto } from "@models/rubikscube/rubiksboxDto.model";
import { RubiksColor } from "@models/rubikscube/rubiks-color.enum";
import { BaseComponent } from "@shared/components/base.component";

@Component({
  selector: 'rubikscube-face',
  templateUrl: './rubikscube-face.component.html',
  styleUrls: ['./rubikscube-face.component.scss']
})
export class RubiksCubeFaceComponent extends BaseComponent implements OnInit {
  @Input() boxes: RubiksBoxDto[][] = [];
  //loading$ = this.store.select(selectLoading);

  readonly colorMap: Record<RubiksColor, string> = {
    [RubiksColor.White]: 'white',
    [RubiksColor.Red]: 'red',
    [RubiksColor.Blue]: 'blue',
    [RubiksColor.Green]: 'green',
    [RubiksColor.Orange]: 'orange',
    [RubiksColor.Yellow]: 'yellow',
  };

  constructor() {
    super();
  }

  ngOnInit(): void {
  }

  getColor(color: RubiksColor) {
    return this.colorMap[color] || 'white';
  }
}
