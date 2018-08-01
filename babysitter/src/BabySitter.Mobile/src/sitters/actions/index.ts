import { SitterModel } from '../models';
import { createAction } from 'redux-actions';

export enum SittersActionTypes {
  LOAD_SITTERS = '[Sitters] Load',
  LOAD_SITTERS_SUCCESS = '[Sitters] Load Success',
  LOAD_SITTERS_FAILED = '[Sitters] Load Failed',
}

const loadSitters = createAction(SittersActionTypes.LOAD_SITTERS);
export type LoadSittersAction = ReturnType<typeof loadSitters>;

const loadSittersSuccess = createAction<SitterModel[]>(SittersActionTypes.LOAD_SITTERS_SUCCESS);
export type LoadSittersSuccessAction = ReturnType<typeof loadSittersSuccess>;

const loadSittersFailed = createAction<any>(SittersActionTypes.LOAD_SITTERS_FAILED);
export type LoadSittersFailedAction = ReturnType<typeof loadSittersFailed>;

export const SittersActions = {
  loadSitters,
  loadSittersSuccess,
  loadSittersFailed,
};
