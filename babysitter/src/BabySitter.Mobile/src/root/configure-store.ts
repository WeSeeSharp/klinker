import { Navigator } from 'react-navigation';
import { createReactNavigationReduxMiddleware } from 'react-navigation-redux-helpers';
import { IRootState } from './root.state';
import { createRootReducer } from './root.reducer';
import { applyMiddleware, createStore } from 'redux';

export const NavigationKey = 'root';
const createNavigationMiddleware = () =>
  createReactNavigationReduxMiddleware(NavigationKey, (state: IRootState) => state.nav);

export const configureStore = (navigator: Navigator) => {
  const rootReducer = createRootReducer(navigator);
  const navigationMiddleware = createNavigationMiddleware();
  return createStore(rootReducer, applyMiddleware(navigationMiddleware));
};
