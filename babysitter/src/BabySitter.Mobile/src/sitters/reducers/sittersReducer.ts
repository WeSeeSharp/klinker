import { handleActions } from 'redux-actions';
import { LoadSittersSuccessAction, SittersActionTypes } from '../actions';
import { SitterModel } from '../models';
import { RootState } from '../../root';

export interface SittersState {
  sitters: {
    [id: string]: SitterModel;
  };
}

export const sittersInitialState: SittersState = {
  sitters: {},
};

export const getSittersArraySelector = ({ sitters: { sitters } = sittersInitialState }: RootState): SitterModel[] =>
  Object.keys(sitters).map((key: string) => sitters[key]);

const loadSittersSuccess = (state: SittersState, action: LoadSittersSuccessAction) => ({
  ...state,
  sitters: {
    ...state.sitters,
    ...(action.payload || []).reduce((obj: { [id: number]: SitterModel }, sitter: SitterModel, index: number) => {
      obj[sitter.id] = sitter;
      return obj;
    }, {}),
  },
});

export const sittersReducer = handleActions(
  {
    [SittersActionTypes.LOAD_SITTERS_SUCCESS]: loadSittersSuccess,
  },
  sittersInitialState
);
