import {History} from 'history';
import {applyMiddleware, compose, createStore, Reducer, Store} from 'redux';
import {connectRouter, routerMiddleware} from "connected-react-router";
import {IAppState} from "./AppState";
import {createEpicMiddleware} from "redux-observable";
import { rootEpic } from './rootEpic';

export const configureStore = (reducer: Reducer, history: History, initialState: IAppState = {}): Store<IAppState> => {
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
    return store
};