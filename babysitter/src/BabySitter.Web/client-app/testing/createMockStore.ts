import configureMockStore from 'redux-mock-store';
import { IAppState } from "../src/AppState";
import { Middleware } from "redux";

export const createMockStore = (state: IAppState = {}, middleware: Middleware[] = []) => {
  return configureMockStore(middleware)(state);
};