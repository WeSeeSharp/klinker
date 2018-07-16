import { AnyAction } from 'redux';
import { ISittersState } from '../sitters.state';
import { createReducerHash } from '../../common';
import { SITTERS } from '../actions';

export const initialState: ISittersState = {
  sitters: {},
  isLoading: false,
  error: null,
};

const startLoadingReducer = (state: ISittersState): ISittersState => ({
  ...state,
  isLoading: true,
});
const loadSuccessReducer = (state: ISittersState, action: AnyAction): ISittersState => ({
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

const loadFailedReducer = (state: ISittersState, action: AnyAction): ISittersState => ({
  ...state,
  isLoading: false,
  error: action.payload,
});

const saveSuccessReducer = (state: ISittersState, action: AnyAction): ISittersState => ({
  ...state,
  isLoading: false,
  sitters: {
    ...state.sitters,
    [action.payload.id]: {
      ...state.sitters[action.payload.id],
      ...action.payload,
    },
  },
});

const saveFailedReducer = (state: ISittersState, action: AnyAction): ISittersState => ({
  ...state,
  isLoading: false,
  error: action.payload,
});

const addBeginReducer = (state: ISittersState): ISittersState => ({
  ...state,
  isAdding: true,
});

const addCancelledReducer = (state: ISittersState): ISittersState => ({
  ...state,
  isAdding: false,
});

const addSuccessReducer = (state: ISittersState, action: AnyAction) => ({
  ...state,
  isAdding: false,
  isLoading: false,
  sitters: {
    [action.payload.id]: action.payload,
  },
});

const addFailedReducer = (state: ISittersState, action: AnyAction) => ({
  ...state,
  isLoading: false,
  error: action.payload,
});

export const sittersReducer = createReducerHash(
  {
    [SITTERS.LOAD]: startLoadingReducer,
    [SITTERS.LOAD_SUCCESS]: loadSuccessReducer,
    [SITTERS.LOAD_FAILED]: loadFailedReducer,

    [SITTERS.SAVE]: startLoadingReducer,
    [SITTERS.SAVE_SUCCESS]: saveSuccessReducer,
    [SITTERS.SAVE_FAILED]: saveFailedReducer,

    [SITTERS.ADD_BEGIN]: addBeginReducer,
    [SITTERS.ADD_CANCELLED]: addCancelledReducer,
    [SITTERS.ADD]: startLoadingReducer,
    [SITTERS.ADD_SUCCESS]: addSuccessReducer,
    [SITTERS.ADD_FAILED]: addFailedReducer,
  },
  initialState
);
