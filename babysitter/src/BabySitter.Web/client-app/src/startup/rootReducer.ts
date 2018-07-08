import { combineReducers } from "redux";
import { IAppState } from "../AppState";
import { sittersReducer } from "../sitters";

const fakeReducer = (state: boolean = false) => state;
export const rootReducer = combineReducers<IAppState>({
  isOpen: fakeReducer,
  sitters: sittersReducer
});