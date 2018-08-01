import * as React from 'react';
import { createStackNavigator } from 'react-navigation';
import { reduxifyNavigator } from 'react-navigation-redux-helpers';
import { connect, Provider } from 'react-redux';

import { configureStore, NavigationKey } from './configure-store';
import { IRootState } from './root.state';

const AppNavigator = createStackNavigator({});

const store = configureStore(AppNavigator);

const AppRoot = reduxifyNavigator(AppNavigator, NavigationKey);
const AppRootWithNavigation = connect((state: IRootState) => ({ state: state.nav }))(AppRoot);

export const Root = () => (
  <Provider store={store}>
    <AppRootWithNavigation />
  </Provider>
);
