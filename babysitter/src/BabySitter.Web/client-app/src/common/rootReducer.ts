import { combineReducers } from "redux";
import { IAppState } from "./AppState";

const fakeReducer = (state: boolean = false) => state;
export const rootReducer = combineReducers<IAppState>({
  isOpen: fakeReducer
});