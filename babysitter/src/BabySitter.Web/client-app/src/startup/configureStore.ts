import { connectRouter, routerMiddleware } from "connected-react-router";
import { History } from "history";
import { applyMiddleware, compose, createStore, DeepPartial, Reducer, Store } from "redux";
import { createEpicMiddleware } from "redux-observable";
import { IAppState } from "../AppState";
import { rootEpic } from "./rootEpic";

export const configureStore = (reducer: Reducer, history: History, initialState: DeepPartial<any> = {}): Store<IAppState> => {
  const epicMiddleware = createEpicMiddleware();

  const store = createStore(
    connectRouter(history)(reducer),
    initialState,
    compose(
      applyMiddleware(
        routerMiddleware(history),
        epicMiddleware
      )
    )
  );
  epicMiddleware.run(rootEpic);
  return store;
};