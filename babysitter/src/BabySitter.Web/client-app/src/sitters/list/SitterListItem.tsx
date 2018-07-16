import React from 'react';
import { createStyles, withStyles, ListItem, ListItemText, WithStyles } from '@material-ui/core';
import { SitterModel } from '../models';
import { Link } from 'react-router-dom';

interface ISitterListItemProps extends WithStyles<typeof styles> {
  sitter: SitterModel;
}

const Component = ({ sitter }: ISitterListItemProps) => (
  <Link to={`/sitters/${sitter.id}`}>
    <ListItem>
      <ListItemText primary={`${sitter.lastName}, ${sitter.firstName}`} />
    </ListItem>
  </Link>
);

const styles = createStyles({});

export const SitterListItem = withStyles(styles)(Component);
