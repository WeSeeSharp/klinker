import React from 'react';
import {
  createStyles,
  WithStyles,
  withStyles,
  Dialog,
  Button,
  DialogActions,
  DialogContent,
  TextField,
  DialogTitle,
  Typography,
} from '@material-ui/core';
import { AddSitterModel } from '../models';
import { SitterForm } from '../common';

interface IAddSitterDialogProps extends WithStyles<typeof styles> {
  isOpen?: boolean;
  onCancelled?: () => any;
  onSaved?: (sitter: AddSitterModel) => any;
}

class Component extends React.Component<IAddSitterDialogProps> {
  state: any = {};

  render() {
    const { isOpen, onCancelled, onSaved } = this.props;
    return (
      <Dialog open={isOpen}>
        <DialogTitle>Add Baby Sitter</DialogTitle>
        <DialogContent>
          <SitterForm onChange={this.onFieldChanged} sitter={this.state} />
        </DialogContent>
        <DialogActions>
          <Button color="default" id="cancelAdd" onClick={onCancelled}>
            Cancel
          </Button>
          <Button color="primary" id="saveAdd" onClick={() => onSaved(this.state)}>
            Save
          </Button>
        </DialogActions>
      </Dialog>
    );
  }

  private onFieldChanged = (fieldName, value) => {
    this.state[fieldName] = value;
  };
}

const styles = createStyles({
  textField: {},
  container: {},
});

export const AddSitterDialog = withStyles(styles)(Component);
