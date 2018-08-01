import { createReducer } from '../../common';
import { LoadSittersSuccessAction, SittersActionTypes } from '../actions';
import { SitterModel } from '../models';
import { IRootState } from '../../root';

export type ISittersState = {
  sitters: {
    [id: string]: SitterModel;
  };
};

export const sittersInitialState: ISittersState = {
  sitters: {},
};

export const getSittersArraySelector = ({ sitters: { sitters } = sittersInitialState }: IRootState): SitterModel[] =>
  Object.keys(sitters).map((key: string) => sitters[key]);

const loadSittersSuccess = (state: ISittersState, action: LoadSittersSuccessAction) => ({
  ...state,
  sitters: {
    ...state.sitters,
    ...action.payload.reduce((obj: { [id: number]: SitterModel }, sitter: SitterModel, index: number) => {
      obj[sitter.id] = sitter;
      return obj;
    }, {}),
  },
});

export const sittersReducer = createReducer(sittersInitialState, {
  [SittersActionTypes.LOAD_SITTERS_SUCCESS]: loadSittersSuccess,
});
