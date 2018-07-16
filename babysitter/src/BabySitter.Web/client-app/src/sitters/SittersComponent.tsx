import React from 'react';
import { WithStyles, withStyles, createStyles, Theme } from '@material-ui/core';
import { SittersListContainer } from './list/SittersListContainer';
import { Switch, Route } from 'react-router';
import { SelectASitter } from './detail/SelectASitterComponent';
import { SitterDetailContainer } from './detail/SitterDetailContainer';
import { AddSitterDialogContainer } from './add-dialog/AddSitterDialogContainer';

interface SittersProps extends WithStyles<typeof styles> {}

const Component = ({ classes }: SittersProps) => (
  <div className={classes.container}>
    <SittersListContainer />
    <Switch>
      <Route exact path="/sitters" component={SelectASitter} />
      <Route path="/sitters/:id" component={SitterDetailContainer} />
    </Switch>
    <AddSitterDialogContainer />
  </div>
);

const styles = (theme: Theme) =>
  createStyles({
    container: {
      flexGrow: 1,
      flexDirection: 'row',
    },
  });
export const Sitters = withStyles(styles)(Component);
