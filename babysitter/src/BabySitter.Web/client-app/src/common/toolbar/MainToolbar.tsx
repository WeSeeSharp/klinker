import { AppBar, IconButton, Toolbar } from "@material-ui/core";
import MenuIcon from '@material-ui/icons/Menu';
import * as React from "react";

interface IMainToolbarProps {
  onToggleDrawer: () => void;
}

export const MainToolbar = ({onToggleDrawer}: IMainToolbarProps) => {
  return (
    <AppBar>
      <Toolbar>
        <IconButton className="drawer-toggle" onClick={onToggleDrawer}>
          <MenuIcon />
        </IconButton>
      </Toolbar>
    </AppBar>
  );
};