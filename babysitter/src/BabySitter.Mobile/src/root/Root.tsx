import * as React from 'react';
import { createStackNavigator } from 'react-navigation';
import { Provider } from 'react-redux';

import { configureStore } from './configure-store';
import { SittersContainer } from '../sitters';

const AppNavigator = createStackNavigator({
  Sitters: {
    screen: SittersContainer,
  },
});

const store = configureStore();
export class Root extends React.Component<any> {
  render() {
    return (
      <Provider store={store}>
        <AppNavigator />
      </Provider>
    );
  }
}
