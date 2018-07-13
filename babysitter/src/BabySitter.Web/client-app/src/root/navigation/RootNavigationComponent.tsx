import React from 'react';
import {
  Drawer,
  withStyles,
  createStyles,
  WithStyles,
  Typography,
  Theme,
} from '@material-ui/core';

interface IRootNavigationProps extends WithStyles<typeof styles> {
  isOpen: boolean;
  onClosed: () => any;
}

const Component = ({ isOpen, onClosed, classes }: IRootNavigationProps) => (
  <Drawer classes={{ paper: classes.drawer }} open={isOpen} onClose={onClosed}>
    <div className={classes.toolbar} />
    <div className={classes.root}>
      <Typography variant="headline">Baby Sitters</Typography>
    </div>
  </Drawer>
);

const styles = (theme: Theme) =>
  createStyles({
    root: {
      width: 250,
    },
    drawer: {
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
