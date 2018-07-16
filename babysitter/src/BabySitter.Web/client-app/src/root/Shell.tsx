import React from 'react';
import { MuiThemeProvider, createMuiTheme, withStyles, Theme, createStyles, WithStyles } from '@material-ui/core';
import green from '@material-ui/core/colors/green';
import pink from '@material-ui/core/colors/pink';
import { RootNavigationContainer } from './navigation';
import { RootAppBarContainer } from './appbar';

interface IShellProps extends WithStyles<typeof styles> {
  children: any;
}

const theme = createMuiTheme({
  palette: {
    primary: green,
    secondary: pink,
  },
});

const Component = ({ children, classes }: IShellProps) => (
  <MuiThemeProvider theme={theme}>
    <div className={classes.root}>
      <RootAppBarContainer />
      <RootNavigationContainer />
      <div className={classes.appbar} />
      {children}
    </div>
  </MuiThemeProvider>
);

const styles = (theme: Theme) =>
  createStyles({
    root: {
      flex: 1,
      flexDirection: 'column',
    },
    appbar: theme.mixins.toolbar,
  });

export const Shell = withStyles(styles)(Component);
