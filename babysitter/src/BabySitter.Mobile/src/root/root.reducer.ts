import { combineReducers } from 'redux';
import { SittersState, sittersReducer } from '../sitters';

export interface RootState {
  sitters?: SittersState;
}

export const createRootReducer = () => {
  return combineReducers<any>({
    sitters: sittersReducer,
  });
};
