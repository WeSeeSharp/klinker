import { combineReducers } from "redux";
import { IAppState } from "../AppState";
import { sittersReducer } from "../sitters";

export const rootReducer = combineReducers<IAppState>({
  sitters: sittersReducer
});