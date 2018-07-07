import { Action } from "redux";

export interface ReducerHash<TState> {
  [actionType: string]: (state: TState, action: Action) => TState;
}

export const createReducerHash = <TState>(hash: ReducerHash<TState>, initialState: TState) => {
  return (state: TState = initialState, action: Action) => {
    return hash[action.type]
      ? hash[action.type](state, action)
      : state;
  };
};