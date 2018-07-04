import * as React from 'react';
import {render} from 'react-dom';
import './index.css';
import registerServiceWorker from './registerServiceWorker';
import {configureStore, rootReducer} from './common';
import {Root} from './Root';
import {createBrowserHistory} from 'history';

const history = createBrowserHistory();
const store = configureStore(rootReducer, history);
render(
    <Root history={history} store={store}/>,
    document.getElementById('root') as HTMLElement
);
registerServiceWorker();
