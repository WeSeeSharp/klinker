import { createMuiTheme } from "@material-ui/core";
import green from '@material-ui/core/colors/green';
import blue from '@material-ui/core/colors/blue';

export const createDefaultTheme = () => {
  return createMuiTheme({
    palette: {
      primary: green,
      secondary: blue
    }
  });
};