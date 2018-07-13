import { History } from 'history';
import { applyMiddleware, createStore, Store } from 'redux';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { composeWithDevTools } from 'redux-devtools-extension';
import { rootReducer } from './root.reducer';
import { IRootState } from './root.state';

export const configureStore = (history: History): Store<IRootState> => {
  const store = createStore(
    connectRouter(history)(rootReducer),
    composeWithDevTools(applyMiddleware(routerMiddleware(history)))
  );

  return store;
};
