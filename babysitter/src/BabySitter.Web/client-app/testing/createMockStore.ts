import configureMockStore from 'redux-mock-store';
import { IAppState } from "../src/common";

export const createMockStore = (state: IAppState = {}) => {
  return configureMockStore([])(state);
};