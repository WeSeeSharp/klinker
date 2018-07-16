import React from 'react';
import { WithStyles, createStyles, withStyles, TextField } from '@material-ui/core';
import { SitterModel, AddSitterModel } from '../models';

interface ISitterFormProps extends WithStyles<typeof styles> {
  sitter: SitterModel | AddSitterModel;
  onChange: (propertyName: string, value: string | number) => any;
  onSubmit?: () => any;
}

const Component = ({
  sitter: { firstName, lastName, hourlyRate, hourlyRateAfterMidnight, hourlyRateBetweenBedtimeAndMidnight },
  classes,
  onSubmit,
  onChange,
}: ISitterFormProps) => {
  const onFieldChanged = (fieldName: string) => ({ currentTarget }: React.SyntheticEvent<HTMLInputElement>) => {
    const value = currentTarget.type === 'number' ? Number(currentTarget.value) : currentTarget.value;
    onChange(fieldName, value);
  };
  return (
    <form className={classes.container} onSubmit={onSubmit}>
      <TextField
        autoFocus
        id="firstName"
        label="First Name"
        onChange={onFieldChanged('firstName')}
        className={classes.textField}
        value={firstName || ''}
      />

      <TextField
        id="lastName"
        label="Last Name"
        onChange={onFieldChanged('lastName')}
        className={classes.textField}
        value={lastName || ''}
      />

      <TextField
        id="hourlyRate"
        label="Hourly Rate"
        className={classes.textField}
        type="number"
        onChange={onFieldChanged('hourlyRate')}
        value={hourlyRate || 0}
      />

      <TextField
        id="hourlyRateBetweenBedtimeAndMidnight"
        label="Rate between bedtime and midnight"
        className={classes.textField}
        type="number"
        onChange={onFieldChanged('hourlyRateBetweenBedtimeAndMidnight')}
        value={hourlyRateBetweenBedtimeAndMidnight || 0}
      />

      <TextField
        id="hourlyRateAfterMidnight"
        label="Rate after midnight"
        className={classes.textField}
        type="number"
        onChange={onFieldChanged('hourlyRateAfterMidnight')}
        value={hourlyRateAfterMidnight || 0}
      />
    </form>
  );
};

const styles = createStyles({
  container: {
    display: 'flex',
    flexDirection: 'column',
    flexWrap: 'wrap',
  },
  textField: {},
});

export const SitterForm = withStyles(styles)(Component);
