import { ConnectedRouter } from "connected-react-router";
import { History } from "history";
import * as React from "react";
import { Provider } from "react-redux";
import { Store } from "redux";
import { MuiThemeProvider } from "@material-ui/core";
import { createDefaultTheme, MainContent, MainToolbar, NavigationDrawer, RouteWithSubRoutes } from "../common";
import { welcomeRoutes } from "../welcome";
import { sittersRoutes } from "../sitters";

interface IRootProps {
  store: Store;
  history: History;
}

export class Root extends React.Component<IRootProps> {
  public state = {
    isDrawerOpen: false,
    theme: createDefaultTheme(),
    routes: [
      ...welcomeRoutes,
      ...sittersRoutes
    ]
  };

  constructor(props: IRootProps) {
    super(props);
    this.onToggleDrawer = this.onToggleDrawer.bind(this);
    this.onCloseDrawer = this.onCloseDrawer.bind(this);
  }

  public render() {
    const { isDrawerOpen, routes, theme } = this.state;
    const { store, history } = this.props;
    const routing = routes.map(r => (<RouteWithSubRoutes key={r.path} {...r}/>));
    return (
      <Provider store={store}>
        <ConnectedRouter history={history}>
          <MuiThemeProvider theme={theme}>
            <MainContent>
              <MainToolbar onToggleDrawer={this.onToggleDrawer}/>
              <NavigationDrawer open={isDrawerOpen} onClose={this.onCloseDrawer}/>
              {routing}
            </MainContent>
          </MuiThemeProvider>
        </ConnectedRouter>
      </Provider>
    );
  }

  private onToggleDrawer() {
    const { isDrawerOpen } = this.state;
    this.setState({ isDrawerOpen: !isDrawerOpen });
  }

  private onCloseDrawer() {
    this.setState({ isDrawerOpen: false });
  }
}