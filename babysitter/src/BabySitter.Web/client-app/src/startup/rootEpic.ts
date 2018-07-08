import { combineEpics } from "redux-observable";
import { IEpicDependencies } from "../common";
import { IAppState } from "../AppState";
import { Action } from "redux";
import { getSittersEpic } from "../sitters/epics";

export const rootEpic = combineEpics<Action, Action, IAppState, IEpicDependencies>(
  getSittersEpic
);