import React from 'react';
import { IRootState } from '../src/root';
import { ReactWrapper, mount } from 'enzyme';
import { Provider } from 'react-redux';
import { Store } from 'redux';
import { MemoryRouter } from 'react-router';

export const mountWithStore = (
  Component: any,
  store: Store<IRootState>,
  pathname: string = ''
): ReactWrapper => {
  return mount(
    <MemoryRouter initialEntries={[{ pathname }]} initialIndex={0}>
      <Provider store={store}>
        <Component />
      </Provider>
    </MemoryRouter>
  );
};
