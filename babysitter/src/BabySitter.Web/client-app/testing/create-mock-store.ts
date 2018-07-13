import configureMockStore, { MockStore } from 'redux-mock-store';
import { Middleware } from 'redux';
import { IRootState } from '../src/root';
import { initialState as navigationInitialState } from '../src/root/navigation';

const testingInitialState: IRootState = {
  navigation: navigationInitialState,
};

export const createMockStore = (
  state: IRootState = null,
  middleware: Middleware[] = []
): MockStore<IRootState> => {
  state = state || testingInitialState;
  return configureMockStore<IRootState>(middleware)(state);
};
