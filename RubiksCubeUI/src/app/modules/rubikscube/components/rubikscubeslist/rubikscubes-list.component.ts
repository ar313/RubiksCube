import { Component, OnInit } from "@angular/core";
import { Store } from "@ngrx/store";
import { selectAllRubiksCubes } from "../../store/rubikscube/rubikscube.selector";
import { takeUntil } from "rxjs";
import { RubiksCubeDto } from "@models/rubikscube/rubikscubeDto.model";
import * as RubiksCubeActions from '../../store/rubikscube/rubikscube.action';
import { Router } from "@angular/router";
import { BaseComponent } from "../../../../shared/components/base.component";

@Component({
  selector: 'rubikscubes-list',
  templateUrl: './rubikscubes-list.component.html',
  styleUrls: ['./rubikscubes-list.component.scss']
})
export class RubiksCubesListComponent extends BaseComponent implements OnInit {
  cubes$ = this.store.select(selectAllRubiksCubes);
  displayedColumns: string[] = ['id', 'action']; 
  cubes: RubiksCubeDto[] = [];

  constructor(private store: Store, private router: Router) {
    super();
  }

  ngOnInit(): void {
    this.cubes$
      .pipe(takeUntil(this.destroy$))
      .subscribe((cubesState) => {
        this.cubes = [...cubesState];
      })
      
  }

  viewRubiksCube(id: string) {
    this.router.navigate(['rubikscube/view', id]);
  }

  createRubiksCube() {
    this.store.dispatch(RubiksCubeActions.createCube());
  }

}
