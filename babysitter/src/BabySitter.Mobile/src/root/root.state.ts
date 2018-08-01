import { ISittersState } from '../sitters';
import { ReducerState } from 'react-navigation-redux-helpers';

export interface IRootState {
  nav: ReducerState;
  sitters?: ISittersState;
}
