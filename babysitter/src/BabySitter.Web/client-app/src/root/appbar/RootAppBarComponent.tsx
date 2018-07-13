import React from 'react';
import {
  createStyles,
  WithStyles,
  withStyles,
  AppBar,
  Toolbar,
  IconButton,
  Typography,
  Theme,
} from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';

interface IRootAppBarProps extends WithStyles<typeof styles> {
  onMenuToggled: () => any;
}

const Component = ({ classes, onMenuToggled }: IRootAppBarProps) => (
  <div className={classes.root}>
    <AppBar position="absolute" className={classes.appBar}>
      <Toolbar>
        <IconButton onClick={onMenuToggled}>
          <MenuIcon />
        </IconButton>
        <Typography variant="title" className={classes.title}>
          Baby Sitters
        </Typography>
      </Toolbar>
    </AppBar>
  </div>
);

const styles = (theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
    },
    appBar: {
      zIndex: theme.zIndex.drawer + 1,
    },
    title: {
      flex: 1,
    },
  });

export const RootAppBar = withStyles(styles)(Component);
