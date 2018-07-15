import React from 'react';
import { WithStyles, withStyles, createStyles, TextField, Button } from '@material-ui/core';
import { SitterModel } from '../models';

interface ISitterDetailProps extends WithStyles<typeof styles> {
  sitter: SitterModel;
  onUpdate: (sitter: SitterModel) => any;
}

class Component extends React.Component<ISitterDetailProps, any> {
  state: any = {};

  constructor(props, context) {
    super(props, context);
    this.onUpdate = this.onUpdate.bind(this);
  }

  render() {
    const { classes, sitter } = this.props;
    const {
      firstName,
      lastName,
      hourlyRate,
      hourlyRateAfterMidnight,
      hourlyRateBetweenBedtimeAndMidnight,
    } = this.state;
    return (
      <form className={classes.container}>
        <TextField
          autoFocus
          id="firstName"
          label="First Name"
          onChange={this.onFieldChanged('firstName')}
          className={classes.textField}
          value={firstName || sitter.firstName}
        />

        <TextField
          id="lastName"
          label="Last Name"
          onChange={this.onFieldChanged('lastName')}
          className={classes.textField}
          value={lastName || sitter.lastName}
        />

        <TextField
          id="hourlyRate"
          label="Hourly Rate"
          className={classes.textField}
          type="number"
          onChange={this.onFieldChanged('hourlyRate')}
          value={hourlyRate || sitter.hourlyRate}
        />

        <TextField
          id="hourlyRateBetweenBedtimeAndMidnight"
          label="Rate between bedtime and midnight"
          className={classes.textField}
          type="number"
          onChange={this.onFieldChanged('hourlyRateBetweenBedtimeAndMidnight')}
          value={hourlyRateBetweenBedtimeAndMidnight || sitter.hourlyRateBetweenBedtimeAndMidnight}
        />

        <TextField
          id="hourlyRateAfterMidnight"
          label="Rate after midnight"
          className={classes.textField}
          type="number"
          onChange={this.onFieldChanged('hourlyRateAfterMidnight')}
          value={hourlyRateAfterMidnight || sitter.hourlyRateAfterMidnight}
        />

        <Button id="update" color="primary" onClick={this.onUpdate}>
          Update
        </Button>
      </form>
    );
  }

  private onUpdate() {
    const { sitter, onUpdate } = this.props;
    onUpdate({ ...sitter, ...this.state });
  }

  private onFieldChanged(fieldName) {
    return (evt: React.SyntheticEvent<HTMLInputElement>) => {
      const value = evt.currentTarget.value;
      this.setState({ [fieldName]: evt.currentTarget.type === 'number' ? Number(value) : value });
    };
  }
}

const styles = createStyles({
  container: {},
  textField: {},
});

export const SitterDetail = withStyles(styles)(Component);
