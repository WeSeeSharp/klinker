import { combineReducers } from 'redux';
import { IRootState } from './root.state';
import { navigationReducer } from './navigation';
import { sittersReducer } from '../sitters';

export const rootReducer = combineReducers<IRootState>({
  navigation: navigationReducer,
  sitters: sittersReducer,
});
