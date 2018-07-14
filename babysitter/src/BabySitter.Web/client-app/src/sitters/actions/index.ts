import { SitterModel } from '../models';

export const SITTERS = {
  LOAD: '[Sitters] Load',
  LOAD_SUCCESS: '[Sitters] Load Success',
  LOAD_FAILED: '[Sitters] Load Failed',
};

const load = () => ({ type: SITTERS.LOAD });
const loadSuccess = (sitters: SitterModel[]) => ({
  type: SITTERS.LOAD_SUCCESS,
  payload: sitters,
});
const loadFailed = (err: any) => ({ type: SITTERS.LOAD_FAILED, payload: err });

export const sittersActionCreators = {
  load,
  loadSuccess,
  loadFailed,
};
