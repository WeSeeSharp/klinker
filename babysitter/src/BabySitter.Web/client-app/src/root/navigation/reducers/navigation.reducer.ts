import { createReducerHash } from '../../../common';
import { INavigationState } from '../INavigationState';
import { NAVIGATION } from '../actions';

export const initialState: INavigationState = {
  isOpen: false,
};

const closedReducer = (state: INavigationState) => ({
  ...state,
  isOpen: false,
});
const toggledReducer = (state: INavigationState) => ({
  ...state,
  isOpen: !state.isOpen,
});

export const navigationReducer = createReducerHash<INavigationState>(
  {
    [NAVIGATION.CLOSED]: closedReducer,
    [NAVIGATION.TOGGLED]: toggledReducer,
  },
  initialState
);
