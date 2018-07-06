import { ConnectedRouter } from "connected-react-router";
import { History } from "history";
import * as React from "react";
import { Provider } from "react-redux";
import { Store } from "redux";
import { MainContent, MainToolbar, NavigationDrawer } from "./common";

interface IRootProps {
  store: Store;
  history: History;
}

export class Root extends React.Component<IRootProps> {
  public state = {
    isDrawerOpen: false
  };

  public render() {
    const { store, history } = this.props;
    return (
      <Provider store={store}>
        <ConnectedRouter history={history}>
          <MainContent>
            <MainToolbar onToggleDrawer={this.onToggleDrawer}/>
            <NavigationDrawer/>
          </MainContent>
        </ConnectedRouter>
      </Provider>
    );
  }

  private onToggleDrawer = () => {
    const { isDrawerOpen } = this.state;
    this.setState({ isDrawerOpen: !isDrawerOpen });
  }
}