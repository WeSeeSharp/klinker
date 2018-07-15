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
const loadSuccess = (sitters: SitterModel[]) => ({
  type: SITTERS.LOAD_SUCCESS,
  payload: sitters,
});
const loadFailed = (err: any) => ({ type: SITTERS.LOAD_FAILED, payload: err });

const save = (sitter: SitterModel) => ({ type: SITTERS.SAVE, payload: sitter });
const saveSuccess = (sitter: SitterModel) => ({ type: SITTERS.SAVE_SUCCESS, payload: sitter });
const saveFailed = (err: any) => ({ type: SITTERS.SAVE_FAILED, payload: err });

export const sittersActionCreators = {
  load,
  loadSuccess,
  loadFailed,
  save,
  saveSuccess,
  saveFailed,
};
