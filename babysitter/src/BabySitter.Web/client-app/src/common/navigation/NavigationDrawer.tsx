import { Drawer } from "@material-ui/core";
import * as React from "react";
import { Link } from "react-router-dom";

interface INavigationDrawerProps {
  open?: boolean;
  onClose?: () => void;
}

export const NavigationDrawer = ({ open, onClose }: INavigationDrawerProps) => {
  return (
    <Drawer open={open} onClose={onClose}>
      <Link to={"/"} onClick={onClose}>Home</Link>
      <Link to={"/sitters"} onClick={onClose}>Sitters</Link>
      <Link to={"/shifts"} onClick={onClose}>Shifts</Link>
    </Drawer>
  );
};