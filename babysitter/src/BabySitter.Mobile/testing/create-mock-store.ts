import { Middleware } from 'redux';
import configureMockStore, { MockStore } from 'redux-mock-store';
import { RootState } from '../src';

export const createMockStore = (state: RootState = {}, middleware: Middleware[] = []): MockStore<RootState> => {
  return configureMockStore<RootState>(middleware)(state);
};
