import * as React from "react";
import { Button, List, ListItem, ListItemText } from "@material-ui/core";
import AddIcon from '@material-ui/icons/Add';
import { SitterModel } from "../models";

interface SittersListProps {
  sitters: SitterModel[];
  onAddSitter: () => void;
}

export const SittersList = ({ sitters, onAddSitter }: SittersListProps) => {
  const items = sitters.map(s => <ListItem key={s.id}>
    <ListItemText primary={`${s.lastName}, ${s.firstName}`} />
  </ListItem>);
  return (
    <div className="sitters-list">
      <List>
        {items}
      </List>

      <Button className="add-sitter" variant="fab" color="primary" aria-label="add" onClick={onAddSitter}>
        <AddIcon />
      </Button>
    </div>
  )
};