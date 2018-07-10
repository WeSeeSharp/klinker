import { AddSitterModel, SitterModel } from "../models";

export const SITTERS = {
  LOAD: "[Sitters] Load",
  LOAD_SUCCESS: "[Sitters] Load Success",
  LOAD_FAILED: "[Sitters] Load Failed",
  ADD: "[Sitters] Add",
  ADD_SUCCESS: "[Sitters] Add Success",
  ADD_FAILED: "[Sitters] Add Failed"
};

export const loadSitters = () => ({ type: SITTERS.LOAD });
export const loadSittersSuccess = (sitters: any[]) => ({ type: SITTERS.LOAD_SUCCESS, payload: sitters });
export const loadSittersFailed = (error: any) => ({ type: SITTERS.LOAD_FAILED, payload: error });

export const addSitter = (sitter: AddSitterModel) => ({ type: SITTERS.ADD, payload: sitter });
export const addSitterSuccess = (sitter: SitterModel) => ({ type: SITTERS.ADD_SUCCESS, payload: sitter });
export const addSitterFailed = (err: any) => ({ type: SITTERS.ADD_FAILED, payload: err });

export const SitterActionCreators = {
  loadSitters,
  loadSittersSuccess,
  loadSittersFailed,
  addSitter,
  addSitterSuccess,
  addSitterFailed
};