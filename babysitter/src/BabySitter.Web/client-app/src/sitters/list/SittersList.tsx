import * as React from "react";
import { Button, List, ListItem, ListItemText, Theme, withStyles } from "@material-ui/core";
import AddIcon from '@material-ui/icons/Add';
import { SitterModel } from "../models";
import { StyleRules } from "@material-ui/core/styles";
import { ClassesProps } from "../../common/theming";

interface SittersListProps {
  sitters: SitterModel[];
  onAddSitter: () => void;
}

const Component = ({ sitters, onAddSitter, classes }: SittersListProps & ClassesProps) => {
  const items = sitters.map(s => <ListItem key={s.id}>
    <ListItemText primary={`${s.lastName}, ${s.firstName}`} />
  </ListItem>);
  return (
    <div className={classes.container}>
      <List>
        {items}
      </List>

      <Button className="add-sitter" variant="fab" color="primary" aria-label="add" onClick={onAddSitter}>
        <AddIcon />
      </Button>
    </div>
  )
};

const styles = (theme: Theme): StyleRules<string> => ({
  container: {
    flexGrow: 1,
    display: 'flex'
  }
});

export const SittersList = withStyles(styles)(Component);