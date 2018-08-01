import { combineReducers } from 'redux';
import { NavigationContainer } from 'react-navigation';
import { createNavigationReducer } from 'react-navigation-redux-helpers';

export const createRootReducer = (navigator: NavigationContainer) => {
  const navReducer = createNavigationReducer(navigator);
  return combineReducers({
    nav: navReducer,
  });
};
