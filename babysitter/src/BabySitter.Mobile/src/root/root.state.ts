import { ReducerState } from 'react-navigation-redux-helpers';
import { ISittersState } from '../sitters';

export interface IRootState {
  nav?: ReducerState;
  sitters?: ISittersState;
}
