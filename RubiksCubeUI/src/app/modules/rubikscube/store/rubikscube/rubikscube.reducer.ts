import { createReducer, on } from '@ngrx/store';
import * as RubiksCubeActions from './rubikscube.action';
import { RubiksCubeDto } from '@models/rubikscube/rubikscubeDto.model';

export interface RubiksCubeState {
  cubes: RubiksCubeDto[];
  loading: boolean;
  error?: string;
}

const initialState: RubiksCubeState = {
  cubes: [],
  loading: false,
};

export const rubiksCubeReducer = createReducer(
  initialState,
  on(RubiksCubeActions.clearCubeError, state => {
    return {
      ...state,
      error: ''
    }
  }),
  on(RubiksCubeActions.loadAllCubes, RubiksCubeActions.loadCube, RubiksCubeActions.rotateCube, RubiksCubeActions.createCube,
    state => ({ ...state, loading: true })),
  on(RubiksCubeActions.loadAllCubesSuccess,
    (state, { cubes }) => {
      const cubesFromRequest = [...cubes];

      return {
        ...state,
        loading: false,
        cubes: cubesFromRequest
      }
    }),
  on(RubiksCubeActions.loadCubeSuccess, RubiksCubeActions.createCubeSuccess, (state, { cube }) =>
  {
    const index = state.cubes.findIndex(f => f.id === cube.id);
    var cubes = [...state.cubes];

    if (index >= 0) { // add or update 
      cubes = cubes.map(f => f.id === cube.id ? cube : f)
    } else {
      cubes = [
        ...state.cubes,
        cube
      ]
    }

    return {
      ...state,
      loading: false,
      cubes: cubes
    }
  }),
  on(RubiksCubeActions.rotateCubeSuccess,
    (state, { cube }) => {
    const index = state.cubes.findIndex(f => f.id === cube.id);
    var cubes = [...state.cubes];

    if (index >= 0) { // update 
      cubes = cubes.map(f => f.id === cube.id ? cube : f)
    }

    return {
      ...state,
      loading: false,
      cubes: cubes
    }
    }),
  on(RubiksCubeActions.loadAllCubesFailure, RubiksCubeActions.loadCubeFailure, RubiksCubeActions.rotateCubeFailure, RubiksCubeActions.createCubeFailure,
    (state, { error }) => ({ ...state, loading: false, error })),

);
