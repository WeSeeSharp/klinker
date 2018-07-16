import React from 'react';
import {
  Drawer,
  withStyles,
  createStyles,
  WithStyles,
  Typography,
  List,
  ListItem,
  ListItemText,
  Theme,
} from '@material-ui/core';
import { Link } from 'react-router-dom';

interface IRootNavigationProps extends WithStyles<typeof styles> {
  isOpen: boolean;
  onClosed: () => any;
}

const NavItem = ({ to, text, onClick }) => (
  <Link to={to} onClick={onClick}>
    <ListItem>
      <ListItemText primary={text} />
    </ListItem>
  </Link>
);

const Component = ({ isOpen, onClosed, classes }: IRootNavigationProps) => (
  <Drawer style={{ display: 'block' }} classes={{ paper: classes.drawer }} open={isOpen} onClose={onClosed}>
    <div className={classes.toolbar} />
    <div className={classes.root}>
      <Typography variant="headline">Baby Sitters</Typography>
      <List>
        <NavItem to="/" text="Welcome" onClick={onClosed} />
        <NavItem to="/sitters" text="Sitters" onClick={onClosed} />
      </List>
    </div>
  </Drawer>
);

const styles = (theme: Theme) =>
  createStyles({
    root: {
      flexDirection: 'column',
      width: 250,
    },
    drawer: {
      display: 'block',
      position: 'relative',
      width: 250,
    },
    content: {
      flexGrow: 1,
      backgroundColor: theme.palette.background.default,
      padding: theme.spacing.unit * 3,
      minWidth: 0,
    },
    toolbar: theme.mixins.toolbar,
  });

export const RootNavigation = withStyles(styles)(Component);
