import { ConnectedRouter } from "connected-react-router";
import { History } from "history";
import * as React from "react";
import { Provider } from "react-redux";
import { Store } from "redux";
import { MainContent, MainToolbar, NavigationDrawer, routes, RouteWithSubRoutes } from "./common";

interface IRootProps {
  store: Store;
  history: History;
}

export class Root extends React.Component<IRootProps> {
  public state = {
    isDrawerOpen: false
  };

  constructor(props: IRootProps) {
    super(props);
    this.onToggleDrawer = this.onToggleDrawer.bind(this);
  }

  public render() {
    const { isDrawerOpen } = this.state;
    const { store, history } = this.props;
    const routing = routes.map(r => (<RouteWithSubRoutes key={r.path} {...r}/>));
    return (
      <Provider store={store}>
        <ConnectedRouter history={history}>
          <MainContent>
            <MainToolbar onToggleDrawer={this.onToggleDrawer}/>
            <NavigationDrawer open={isDrawerOpen}/>
            {routing}
          </MainContent>
        </ConnectedRouter>
      </Provider>
    );
  }

  private readonly onToggleDrawer = () => {
    const { isDrawerOpen } = this.state;
    this.setState({ isDrawerOpen: !isDrawerOpen });
  }
}