import React from 'react';
import { WithStyles, withStyles, createStyles, Button } from '@material-ui/core';
import { SitterModel } from '../models';
import { SitterForm } from '../common';

interface ISitterDetailProps extends WithStyles<typeof styles> {
  sitter: SitterModel;
  onUpdate: (sitter: SitterModel) => any;
}

class Component extends React.Component<ISitterDetailProps, any> {
  state: any = {};

  get sitter(): SitterModel {
    const { sitter } = this.props;
    return { ...sitter, ...this.state };
  }

  render() {
    const { classes } = this.props;
    return (
      <div className={classes.container}>
        <SitterForm onChange={this.onFieldChanged} sitter={this.sitter} />
        <Button id="update" color="primary" onClick={this.onUpdate}>
          Update
        </Button>
      </div>
    );
  }

  private onUpdate = () => {
    const { onUpdate } = this.props;
    onUpdate(this.sitter);
  };

  private onFieldChanged = (fieldName, value) => {
    this.state[fieldName] = value;
  };
}

const styles = createStyles({
  container: {
    flex: 1,
    flexDirection: 'column',
  },
  textField: {},
});

export const SitterDetail = withStyles(styles)(Component);
