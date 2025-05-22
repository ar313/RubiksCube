import { Component, OnInit } from "@angular/core";
import { Store } from "@ngrx/store";
import { Observable, of, takeUntil } from "rxjs";
import { RubiksCubeDto } from "@models/rubikscube/rubikscubeDto.model";
import { RubiksFace } from "../../../../models/rubikscube/rubiks-face.enum";
import { RubiksBoxDto } from "../../../../models/rubikscube/rubiksboxDto.model";
import { ActivatedRoute, Router } from "@angular/router";
import { selectRubiksCubeFaceById } from "../../store/rubikscube/rubikscube.selector";
import * as RubiksCubeActions from '../../store/rubikscube/rubikscube.action';
import { RubiksRotation } from "../../../../models/rubikscube/rubiks-rotation.enum";
import { BaseComponent } from "../../../../shared/components/base.component";
import { BuildButtons, ButtonConfig } from "./button-config";

@Component({
  selector: 'rubikscube-exploded-view',
  templateUrl: './rubikscube-exploded-view.component.html',
  styleUrls: ['./rubikscube-exploded-view.component.scss']
})
export class RubiksCubeExplodedViewComponent extends BaseComponent implements OnInit {

  RubiksFace = RubiksFace;
  RubiksRotation = RubiksRotation;
  cube: RubiksCubeDto | null = null;
  id: string | null = null;

  faces: Record<RubiksFace, RubiksBoxDto[][]> | null = null;
  cube$: Observable<RubiksCubeDto | undefined> = of(undefined);
  buttons: ButtonConfig[] = BuildButtons();
  buttonsClockwise: ButtonConfig[] = [];
  buttonsCounterClockwise: ButtonConfig[] = [];
  constructor(private route: ActivatedRoute, private store: Store, private router: Router) {
    super();
  }

  ngOnInit(): void {
    this.buttonsClockwise = this.buttons.filter(btns => btns.rotation == RubiksRotation.Clockwise);
    this.buttonsCounterClockwise = this.buttons.filter(btns => btns.rotation == RubiksRotation.CounterClockwise);

    var id = this.route.snapshot.paramMap.get('id');
    this.id = id;
    this.cube$ = this.store.select(selectRubiksCubeFaceById(id ?? ""));

    this.cube$.pipe(takeUntil(this.destroy$))
      .subscribe((cube) => {
        if (cube) {
          this.cube = cube;
          this.faces = this.buildFaceMap(cube.rubiksBoxesDto);
        }
      });
  }

  ngOnChanges(): void {
    if (this.cube) {
      this.faces = this.buildFaceMap(this.cube.rubiksBoxesDto);
    }
  }

  private buildFaceMap(boxes: RubiksBoxDto[]): Record<RubiksFace, RubiksBoxDto[][]> {
    const faceMap: Partial<Record<RubiksFace, RubiksBoxDto[][]>> = {};

    const numericFaces = Object.values(RubiksFace).filter(v => typeof v === 'number') as RubiksFace[];

    numericFaces.forEach(faceKey => {
      const faceBoxes = boxes.filter(b => b.face === faceKey);
      const grid: RubiksBoxDto[][] = [[], [], []];

      faceBoxes.forEach(box => {
        grid[box.row] = grid[box.row] || [];
        grid[box.row][box.column] = box;
      });

      faceMap[faceKey] = grid;
    });

    return faceMap as Record<RubiksFace, RubiksBoxDto[][]>;
  }

  rotateCube(face: RubiksFace, rotation: RubiksRotation) {
    this.store.dispatch(RubiksCubeActions.rotateCube({
      id: this.id ?? '', rotateCubeDto: {
        rubiksRotation: rotation,
        faceRubikToRotate: face
      }
    }));
  }

  back() {
    this.router.navigate(['rubikscube']);
  }
}
