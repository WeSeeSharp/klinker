import { combineReducers } from 'redux';
import { IRootState } from './root.state';
import { navigationReducer } from './navigation';

export const rootReducer = combineReducers<IRootState>({
  navigation: navigationReducer,
});
