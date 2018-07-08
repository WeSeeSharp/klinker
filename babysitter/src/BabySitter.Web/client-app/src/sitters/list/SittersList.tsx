import * as React from "react";
import { List, ListItem, ListItemText } from '@material-ui/core';
import { SitterModel } from "../models";

interface SittersListProps {
  sitters: SitterModel[];
}

export const SittersList = ({ sitters }: SittersListProps) => {
  const items = sitters.map(s => <ListItem key={s.id}>
    <ListItemText primary={`${s.lastName}, ${s.firstName}`} />
  </ListItem>);
  return (
    <div className="sitters-list">
      <List>
        {items}
      </List>
    </div>
  )
};