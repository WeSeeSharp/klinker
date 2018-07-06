import { Drawer } from "@material-ui/core";
import * as React from "react";
import { Link } from "react-router-dom";

interface INavigationDrawerProps {
  open?: boolean;
}

export const NavigationDrawer = ({ open }: INavigationDrawerProps) => {
  return (
    <Drawer open={open}>
      <Link to={"/"}>Home</Link>
      <Link to={"/sitters"}>Sitters</Link>
      <Link to={"/shifts"}>Shifts</Link>
    </Drawer>
  );
};