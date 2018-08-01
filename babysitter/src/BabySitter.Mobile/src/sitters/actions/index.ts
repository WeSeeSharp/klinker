import { SitterModel } from '../models';
import { ActionsUnion, createAction } from '../../common';

export enum SittersActionTypes {
  LOAD_SITTERS = '[Sitters] Load',
  LOAD_SITTERS_SUCCESS = '[Sitters] Load Success',
  LOAD_SITTERS_FAILED = '[Sitters] Load Failed',
}

const loadSitters = () => createAction(SittersActionTypes.LOAD_SITTERS);
export type LoadSittersAction = ReturnType<typeof loadSitters>;

const loadSittersSuccess = (sitters: SitterModel[]) => createAction(SittersActionTypes.LOAD_SITTERS_SUCCESS, sitters);
export type LoadSittersSuccessAction = ReturnType<typeof loadSittersSuccess>;

const loadSittersFailed = (error: any) => createAction(SittersActionTypes.LOAD_SITTERS_FAILED, error);
export type LoadSittersFailedAction = ReturnType<typeof loadSittersFailed>;

export const SittersActions = {
  loadSitters,
  loadSittersSuccess,
  loadSittersFailed,
};

export type Actions = ActionsUnion<typeof SittersActions>;
