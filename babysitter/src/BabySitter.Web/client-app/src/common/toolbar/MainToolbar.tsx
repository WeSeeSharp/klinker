import { AppBar, IconButton, Theme, Toolbar, withStyles } from "@material-ui/core";
import { StyleRules } from '@material-ui/core/styles/withStyles'
import MenuIcon from '@material-ui/icons/Menu';
import * as React from "react";
import { ClassesProps } from "../theming";

interface IMainToolbarProps {
  onToggleDrawer: () => void;
}

const Component = ({onToggleDrawer, classes}: IMainToolbarProps & ClassesProps) => {
  return (
    <AppBar position="absolute" className={classes.toolbar}>
      <Toolbar>
        <IconButton className="drawer-toggle" onClick={onToggleDrawer}>
          <MenuIcon />
        </IconButton>
      </Toolbar>
    </AppBar>
  );
};

const styles = (theme: Theme): StyleRules<string> => ({
  toolbar: {
    zIndex: theme.zIndex.drawer + 1
  }
});

export const MainToolbar = withStyles(styles)(Component);