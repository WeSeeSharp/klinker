import { Middleware } from 'redux';
import configureMockStore, { MockStore } from 'redux-mock-store';
import { IRootState } from '../src';

export const createMockStore = (state: IRootState = {}, middleware: Middleware[] = []): MockStore<IRootState> => {
  return configureMockStore<IRootState>(middleware)(state);
};
