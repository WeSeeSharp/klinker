import React from 'react';
import { SitterModel } from '../models';
import { createStyles, WithStyles, List, ListItem, ListItemText, withStyles, Theme, Button } from '@material-ui/core';
import AddIcon from '@material-ui/icons/Add';
import { SitterListItem } from './SitterListItem';

interface ISittersListProps extends WithStyles<typeof styles> {
  sitters: SitterModel[];
  onLoad: () => any;
  onAdd: () => any;
}
class Component extends React.Component<ISittersListProps> {
  componentDidMount() {
    const { onLoad } = this.props;
    onLoad();
  }

  render() {
    const { sitters, onAdd, classes } = this.props;

    return (
      <div className={classes.container}>
        <List>{sitters.map(sitter => <SitterListItem key={sitter.id} sitter={sitter} />)}</List>
        <Button color="primary" id="addSitter" variant="fab" className={classes.addButton} onClick={onAdd}>
          <AddIcon />
        </Button>
      </div>
    );
  }
}

const styles = (theme: Theme) =>
  createStyles({
    container: {},
    addButton: {
      position: 'absolute',
      bottom: theme.spacing.unit * 3,
      right: theme.spacing.unit * 3,
    },
  });

export const SittersList = withStyles(styles)(Component);
