import * as React from 'react';
import { Provider } from 'react-redux';
import { Store } from 'redux';
import { mount, ReactWrapper } from 'enzyme';
import { RootState } from '../src';

export const mountWithStore = (Component: any, store: Store<RootState>, props: any = {}): ReactWrapper => {
  return mount(
    <Provider store={store}>
      <Component {...props} />
    </Provider>
  );
};
