import { History } from 'history';
import { applyMiddleware, createStore, Store, Action } from 'redux';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { composeWithDevTools } from 'redux-devtools-extension';
import { rootReducer } from './root.reducer';
import { IRootState } from './root.state';
import { createEpicMiddleware } from 'redux-observable';
import { rootEpic } from './root.epic';
import { IEpicDependencies, getConfig } from '../common';

export const configureStore = (history: History): Store<IRootState> => {
  const epicMiddleware = createEpicMiddleware<Action, Action, IRootState, IEpicDependencies>({
    dependencies: {
      baseUrl: getConfig().baseUrl,
    },
  });
  const store = createStore(
    connectRouter(history)(rootReducer),
    composeWithDevTools(applyMiddleware(routerMiddleware(history), epicMiddleware))
  );

  epicMiddleware.run(rootEpic);
  return store;
};
