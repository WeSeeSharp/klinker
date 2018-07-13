import React from 'react';
import { Store } from 'redux';
import { History } from 'history';
import { Provider } from 'react-redux';
import { IRootState } from './root.state';
import { Switch, Route } from 'react-router-dom';
import { ConnectedRouter } from 'connected-react-router';
import { Shell } from './Shell';
import { Welcome } from '../welcome/Welcome';

interface IRootProps {
  store: Store<IRootState>;
  history: History;
}

export const Root = ({ store, history }: IRootProps) => (
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <Shell>
        <Switch>
          <Route exact path="/" component={Welcome} />
        </Switch>
      </Shell>
    </ConnectedRouter>
  </Provider>
);
