import { createFeatureSelector, createSelector } from '@ngrx/store';
import { RubiksCubeState } from './rubikscube.reducer';

export const selectRubiksCubeState = createFeatureSelector<RubiksCubeState>('rubiksCubeState');
export const selectAllRubiksCubes = createSelector(selectRubiksCubeState, state => state.cubes);
export const selectRubiksCubeLoading = createSelector(selectRubiksCubeState, state => state.loading);
export const selectRubiksCubeError = createSelector(selectRubiksCubeState, state => state.error);

export const selectRubiksCubeFaceById = (id: string) =>
  createSelector(selectRubiksCubeState, (state) => { const cube = state.cubes.find(cube => cube.id === id); return cube; });
