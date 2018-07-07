import configureMockStore from 'redux-mock-store';
import { IAppState } from "../src/common";
import { Middleware } from "redux";

export const createMockStore = (state: IAppState = {}, middleware: Middleware[] = []) => {
  return configureMockStore(middleware)(state);
};