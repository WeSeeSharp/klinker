import { SitterModel } from '../models';

export const SITTERS = {
  LOAD: '[Sitters] Load',
  LOAD_SUCCESS: '[Sitters] Load Success',
  LOAD_FAILED: '[Sitters] Load Failed',
  SAVE: '[Sitters] Save',
  SAVE_SUCCESS: '[Sitters] Save Success',
  SAVE_FAILED: '[Sitters] Save Failed',
};

const load = () => ({ type: SITTERS.LOAD });
const loadSuccess = (payload: SitterModel[]) => ({
  type: SITTERS.LOAD_SUCCESS,
  payload,
});
const loadFailed = (payload: any) => ({ type: SITTERS.LOAD_FAILED, payload });

const save = (payload: SitterModel) => ({ type: SITTERS.SAVE, payload });
const saveSuccess = (payload: SitterModel) => ({ type: SITTERS.SAVE_SUCCESS, payload });
const saveFailed = (payload: any) => ({ type: SITTERS.SAVE_FAILED, payload });

export const sittersActionCreators = {
  load,
  loadSuccess,
  loadFailed,
  save,
  saveSuccess,
  saveFailed,
};
