import { createAction, props } from '@ngrx/store';
import { RubiksCubeDto } from '@models/rubikscube/rubikscubeDto.model';
import { RotateCubeDto } from '../../../../models/rubikscube/rotateCubeDto.model';

export const clearCubeError = createAction('[Cube] Clear Cube Error');

export const loadAllCubes = createAction('[Cube] Load All Cubes');
export const loadAllCubesSuccess = createAction('[Cube] Load All Cubes Success', props<{ cubes: RubiksCubeDto[] }>());
export const loadAllCubesFailure = createAction('[Cube] Load All Cubes Failure', props<{ error: string }>());

export const loadCube = createAction('[Cube] Load Cube', props<{ id: string }>());
export const loadCubeSuccess = createAction('[Cube] Load Cube Success', props<{ cube: RubiksCubeDto }>());
export const loadCubeFailure = createAction('[Cube] Load Cube Failure', props<{ error: string }>());

export const rotateCube = createAction('[Cube] Rotate Cube', props<{ id: string, rotateCubeDto: RotateCubeDto }>());
export const rotateCubeSuccess = createAction('[Cube] Rotate Cube Success', props<{ cube: RubiksCubeDto }>());
export const rotateCubeFailure = createAction('[Cube] Rotate Cube Failure', props<{ error: string }>());

export const createCube = createAction('[Cube] Create Cube');
export const createCubeSuccess = createAction('[Cube] Create Cube Success', props<{ cube: RubiksCubeDto }>());
export const createCubeFailure = createAction('[Cube] Create Cube Failure', props<{ error: string }>());
