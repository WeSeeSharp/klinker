import React from 'react';
import { IRootState } from '../src/root';
import { LocationDescriptor } from 'history';
import { ReactWrapper, mount } from 'enzyme';
import { Provider } from 'react-redux';
import { Store } from 'redux';
import { MemoryRouter } from 'react-router';

export const mountWithStore = (
  Component: any,
  store: Store<IRootState>,
  pathname: string | LocationDescriptor = ''
): ReactWrapper => {
  const entry = typeof pathname === 'string' ? { pathname } : pathname;
  return mount(
    <MemoryRouter initialEntries={[entry]} initialIndex={0}>
      <Provider store={store}>
        <Component />
      </Provider>
    </MemoryRouter>
  );
};
