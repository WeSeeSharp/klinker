export const SITTERS = {
  LOAD: "[Sitters] Load",
  LOAD_SUCCESS: "[Sitters] Load Success",
  LOAD_FAILED: "[Sitters] Load Failed"
};

export const loadSitters = () => ({ type: SITTERS.LOAD });
export const loadSittersSuccess = (sitters: any[]) => ({ type: SITTERS.LOAD_SUCCESS, payload: sitters });
export const loadSittersFailed = (error: any) => ({ type: SITTERS.LOAD_SUCCESS, payload: error });

export const SitterActionCreators = {
  loadSitters,
  loadSittersSuccess,
  loadSittersFailed
};