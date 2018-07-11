import { IAppState } from "../../AppState";

export const getIsAddingSitter = ({ sitters = { isAdding: false } }: IAppState) => {
  return sitters.isAdding;
};