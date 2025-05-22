import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as RubiksCubeActions from './rubikscube.action';
import { RubiksCubeService } from '@services/rubikscube.service';
import { catchError, map, mergeMap, of } from 'rxjs';

@Injectable()
export class RubiksCubeEffects {
  constructor(private actions$: Actions, private cubeService: RubiksCubeService) { }

  loadAllCubes$ = createEffect(() =>
    this.actions$.pipe(
      ofType(RubiksCubeActions.loadAllCubes),
      mergeMap(() =>
        this.cubeService.getAllCubes().pipe(
          map(cubes => RubiksCubeActions.loadAllCubesSuccess({ cubes })),
          catchError(error => of(RubiksCubeActions.loadAllCubesFailure({ error: error.message })))
        )
      )
    )
  );

  loadCube$ = createEffect(() =>
    this.actions$.pipe(
      ofType(RubiksCubeActions.loadCube),
      mergeMap(({ id }) =>
        this.cubeService.getCube(id).pipe(
          map(cube => RubiksCubeActions.loadCubeSuccess({ cube })),
          catchError(error => of(RubiksCubeActions.loadCubeFailure({ error: error.message })))
        )
      )
    )
  );

  rotateFace$ = createEffect(() =>
    this.actions$.pipe(
      ofType(RubiksCubeActions.rotateCube),
      mergeMap(({id, rotateCubeDto }) =>
        this.cubeService.rotateCube(id, rotateCubeDto).pipe(
          map(cube => RubiksCubeActions.rotateCubeSuccess({ cube })),
          catchError(error => of(RubiksCubeActions.rotateCubeFailure({ error: error.message })))
        )
      )
    )
  );

  createCube$ = createEffect(() =>
    this.actions$.pipe(
      ofType(RubiksCubeActions.createCube),
      mergeMap(() =>
        this.cubeService.createCube().pipe(
          map(cube => RubiksCubeActions.createCubeSuccess({ cube })),
          catchError(error => of(RubiksCubeActions.createCubeFailure({ error: error.message })))
        )
      )
    )
  );
}
