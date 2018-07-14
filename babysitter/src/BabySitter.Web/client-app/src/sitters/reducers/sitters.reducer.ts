import { AnyAction } from 'redux';
import { ISittersState } from '../sitters.state';
import { createReducerHash } from '../../common';
import { SITTERS } from '../actions';

export const initialState: ISittersState = {
  sitters: {},
  isLoading: false,
  error: null,
};

const loadReducer = (state: ISittersState): ISittersState => ({
  ...state,
  isLoading: true,
});
const loadSuccessReducer = (
  state: ISittersState,
  action: AnyAction
): ISittersState => ({
  ...state,
  isLoading: false,
  sitters: {
    ...state.sitters,
    ...action.payload.reduce((map, sitter) => {
      map[sitter.id] = sitter;
      return map;
    }, {}),
  },
});

const loadFailedReducer = (
  state: ISittersState,
  action: AnyAction
): ISittersState => ({
  ...state,
  isLoading: false,
  error: action.payload,
});

export const sittersReducer = createReducerHash(
  {
    [SITTERS.LOAD]: loadReducer,
    [SITTERS.LOAD_SUCCESS]: loadSuccessReducer,
    [SITTERS.LOAD_FAILED]: loadFailedReducer,
  },
  initialState
);
