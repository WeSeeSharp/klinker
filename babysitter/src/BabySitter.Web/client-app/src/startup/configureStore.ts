import { connectRouter, routerMiddleware } from "connected-react-router";
import { History } from "history";
import { Action, applyMiddleware, compose, createStore, DeepPartial, Reducer, Store } from "redux";
import { createEpicMiddleware } from "redux-observable";
import { IAppState } from "../AppState";
import { rootEpic } from "./rootEpic";
import { ajax } from "rxjs/ajax";
import { IEpicDependencies } from "../common";

const composeEnhancers = (<any>window).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export const configureStore = (reducer: Reducer, history: History, initialState: DeepPartial<any> = {}): Store<IAppState> => {
  const epicMiddleware = createEpicMiddleware<Action, Action, IAppState, IEpicDependencies>({
    dependencies: {
      baseUrl: 'https://localhost:5001',
      getJSON: ajax.getJSON
    }
  });

  const store = createStore(
    connectRouter(history)(reducer),
    initialState,
    composeEnhancers(
      applyMiddleware(
        routerMiddleware(history),
        epicMiddleware
      )
    )
  );
  epicMiddleware.run(rootEpic);
  return store;
};