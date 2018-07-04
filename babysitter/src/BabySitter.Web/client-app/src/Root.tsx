import * as React from 'react';
import {Store} from 'redux';
import {Provider} from "react-redux";
import { History } from 'history';
import { Drawer } from '@material-ui/core';
import { ConnectedRouter } from 'connected-react-router';

interface RootProps {
    store: Store;
    history: History;
}

export const Root = (props: RootProps) => {
    const {store, history} = props;
    return (
        <Provider store={store}>
            <ConnectedRouter history={history}>
                <Drawer>
                    
                </Drawer>
            </ConnectedRouter>
        </Provider>
    )
};