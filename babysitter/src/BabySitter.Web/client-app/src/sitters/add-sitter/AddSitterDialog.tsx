import * as React from "react";
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from "@material-ui/core";
import { AddSitterModel } from "../models";

interface IAddSitterDialogProps {
  open: boolean;
  onSave: (sitter: AddSitterModel) => void;
  onCancel: () => void;
}

interface IAddSitterDialogState {
  [key: string]: string;
}

export class AddSitterDialog extends React.Component<IAddSitterDialogProps, IAddSitterDialogState> {
  state = {
    firstName: "",
    lastName: ""
  };

  render() {
    const { open, onCancel } = this.props;
    const { firstName, lastName } = this.state;
    return (
      <Dialog open={open}>
        <DialogTitle>
          Add Baby Sitter
        </DialogTitle>
        <DialogContent>
          <form>
            <TextField autoFocus
                       id="firstName"
                       label="First Name"
                       fullWidth
                       value={firstName}
                       onChange={this.handleChange("firstName")}/>

            <TextField id="lastName"
                       label="Last Name"
                       fullWidth
                       value={lastName}
                       onChange={this.handleChange("lastName")}/>
          </form>
        </DialogContent>
        <DialogActions>
          <Button className="save-sitter" onClick={this.handleSave}>
            Save
          </Button>
          <Button className="cancel-sitter" onClick={onCancel}>
            Cancel
          </Button>
        </DialogActions>
      </Dialog>
    );
  }

  private handleChange = (fieldName: string) => (event: React.FormEvent<HTMLInputElement>) => {
    this.setState({ [fieldName]: event.currentTarget.value });
  };

  private handleSave = () => {
    const { onSave } = this.props;
    onSave(this.state);
  }
}