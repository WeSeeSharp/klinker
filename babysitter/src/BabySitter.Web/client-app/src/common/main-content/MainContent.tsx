import * as React from "react";
import { Theme, withStyles } from "@material-ui/core";
import { ClassesProps } from "../theming";
import { StyleRules } from "@material-ui/core/styles";

interface IMainContentProps {
  children: any;
}

const Component = ({ children, classes }: IMainContentProps & ClassesProps) => {
  return (
    <main className={classes.main}>
      <div className={classes.toolbar}/>
      {children}
    </main>
  );
};

const styles = (theme: Theme): StyleRules<string> => ({
  main: {
    flexGrow: 1,
    padding: theme.spacing.unit * 3,
    minWidth: 0,
    flex: 1
  },
  toolbar: theme.mixins.toolbar
});

export const MainContent = withStyles(styles)(Component);