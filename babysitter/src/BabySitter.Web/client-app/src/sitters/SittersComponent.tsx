import React from 'react';
import { WithStyles, withStyles, createStyles } from '@material-ui/core';
import { SittersListContainer } from './list/SittersListContainer';
import { Switch, Route } from 'react-router';
import { SelectASitter } from './detail/SelectASitterComponent';
import { SitterDetailContainer } from './detail/SitterDetailContainer';

interface SittersProps extends WithStyles<typeof styles> {}

const Component = ({  }: SittersProps) => (
  <div>
    <SittersListContainer />
    <Switch>
      <Route exact path="/" component={SelectASitter} />
      <Route path="/:id" component={SitterDetailContainer} />
    </Switch>
  </div>
);

const styles = createStyles({});
export const Sitters = withStyles(styles)(Component);
