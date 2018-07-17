import { SitterModel, AddSitterModel } from '../models';
import { push } from 'connected-react-router';

export const SITTERS = {
  LOAD: '[Sitters] Load',
  LOAD_SUCCESS: '[Sitters] Load Success',
  LOAD_FAILED: '[Sitters] Load Failed',
  SAVE: '[Sitters] Save',
  SAVE_SUCCESS: '[Sitters] Save Success',
  SAVE_FAILED: '[Sitters] Save Failed',
  ADD_BEGIN: '[Sitters] Add Begin',
  ADD_CANCELLED: '[Sitters] Add Cancelled',
  ADD: '[Sitters] Add',
  ADD_SUCCESS: '[Sitters] Add Success',
  ADD_FAILED: '[Sitters] Add Failed',
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

const addBegin = () => ({ type: SITTERS.ADD_BEGIN });
const addCancelled = () => ({ type: SITTERS.ADD_CANCELLED });
const add = (payload: AddSitterModel) => ({ type: SITTERS.ADD, payload });
const addSuccess = (payload: SitterModel) => ({ type: SITTERS.ADD_SUCCESS, payload });
const addFailed = (payload: any) => ({ type: SITTERS.ADD_FAILED, payload });
const goTo = (id: number) => push(`/sitters/${id}`);

export const sittersActionCreators = {
  load,
  loadSuccess,
  loadFailed,
  save,
  saveSuccess,
  saveFailed,
  addBegin,
  addCancelled,
  add,
  addSuccess,
  addFailed,
  goTo,
};
