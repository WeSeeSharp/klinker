import { ConnectedRouter } from "connected-react-router";
import { History } from "history";
import * as React from "react";
import { Provider } from "react-redux";
import { Store } from "redux";
import { StyleRules } from '@material-ui/core/styles/withStyles'
import { MuiThemeProvider, Theme, withStyles, WithTheme } from "@material-ui/core";
import { createDefaultTheme, MainContent, MainToolbar, NavigationDrawer, RouteWithSubRoutes } from "../common";
import { welcomeRoutes } from "../welcome";
import { sittersRoutes } from "../sitters";

interface IRootProps {
  store: Store;
  history: History;
}

class Component extends React.Component<IRootProps & Partial<WithTheme> & { classes: Record<never, string> }> {
  public state = {
    isDrawerOpen: false,
    theme: createDefaultTheme(),
    routes: [
      ...welcomeRoutes,
      ...sittersRoutes
    ]
  };

  constructor(props: IRootProps & Partial<WithTheme> & { classes: Record<never, string> }) {
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
            <div className="root">
              <MainToolbar onToggleDrawer={this.onToggleDrawer}/>
              <NavigationDrawer open={isDrawerOpen} onClose={this.onCloseDrawer}/>
              <MainContent>
                {routing}
              </MainContent>
            </div>
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

const styles = (theme: Theme): StyleRules<string> => ({
  root: {
    flexGrow: 1,
    display: 'flex',
    overflow: 'hidden',
    position: 'relative',
    zIndex: 1
  },
});

export const Root = withStyles(styles)(Component);