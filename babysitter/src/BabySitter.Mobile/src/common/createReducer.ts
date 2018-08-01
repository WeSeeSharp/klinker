import { Action } from './action';

interface Reducer<TState> {
  (state: TState, action: any): TState;
}

export const createReducer = <T>(initialState: T, map: { [actionType: string]: Reducer<T> }): Reducer<T> => {
  return (state: T, action: Action<any>): T => {
    const newState = state || initialState;
    return map.hasOwnProperty(action.type) ? map[action.type](newState, action) : newState;
  };
};
