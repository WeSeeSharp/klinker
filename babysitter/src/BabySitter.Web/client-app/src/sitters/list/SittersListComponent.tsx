import React from 'react';
import { SitterModel } from '../models';
import {
  createStyles,
  WithStyles,
  List,
  ListItem,
  ListItemText,
  withStyles,
} from '@material-ui/core';

interface ISittersListProps extends WithStyles<typeof styles> {
  sitters: SitterModel[];
  onLoad: () => any;
}
class Component extends React.Component<ISittersListProps> {
  componentDidMount() {
    const { onLoad } = this.props;
    onLoad();
  }

  render() {
    const { sitters } = this.props;

    return (
      <List>
        {sitters.map(sitter => (
          <ListItem key={sitter.id}>
            <ListItemText primary={`${sitter.lastName}, ${sitter.firstName}`} />
          </ListItem>
        ))}
      </List>
    );
  }
}

const styles = createStyles({});

export const SittersList = withStyles(styles)(Component);
