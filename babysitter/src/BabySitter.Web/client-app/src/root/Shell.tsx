import React from 'react';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core';
import green from '@material-ui/core/colors/green';
import pink from '@material-ui/core/colors/pink';
import { RootNavigationContainer } from './navigation';
import { RootAppBarContainer } from './appbar';

interface IShellProps {
  children: any;
}

const theme = createMuiTheme({
  palette: {
    primary: green,
    secondary: pink,
  },
});
export const Shell = ({ children }: IShellProps) => (
  <MuiThemeProvider theme={theme}>
    <div>
      <RootAppBarContainer />
      <RootNavigationContainer />
      {children}
    </div>
  </MuiThemeProvider>
);
