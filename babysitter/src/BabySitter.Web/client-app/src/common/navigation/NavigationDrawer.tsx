import { Drawer, List, ListItem, ListItemText, Typography } from "@material-ui/core";
import * as React from "react";
import { Link } from "react-router-dom";
import './navigation-drawer.css';

interface INavigationDrawerProps {
  open?: boolean;
  onClose?: () => void;
}

export const NavigationDrawer = ({ open, onClose }: INavigationDrawerProps) => {
  return (
    <Drawer open={open} onClose={onClose} className="navigation-drawer">
      <div className="logo-container">
        <img className="logo" src={require("../../images/logo_40.png")}/>
        <Typography variant="display1">Baby Sitters</Typography>
      </div>
      <List className="links-list">
        <Link to={"/"} onClick={onClose}>
          <ListItem button>
            <ListItemText primary="Home"/>
          </ListItem>
        </Link>
        <Link to={"/sitters"} onClick={onClose}>
          <ListItem button>
            <ListItemText primary="Sitters"/>
          </ListItem>
        </Link>
        <Link to={"/shifts"} onClick={onClose}>
          <ListItem button>
            <ListItemText primary="Shifts"/>
          </ListItem>
        </Link>
      </List>
    </Drawer>
  );
};