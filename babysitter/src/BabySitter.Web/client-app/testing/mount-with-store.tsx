import React from 'react';
import { IRootState } from '../src/root';
import { ReactWrapper, mount } from 'enzyme';
import { Provider } from 'react-redux';
import { Store } from 'redux';

export const mountWithStore = (
  Component: any,
  store: Store<IRootState>
): ReactWrapper => {
  return mount(
    <Provider store={store}>
      <Component />
    </Provider>
  );
};
