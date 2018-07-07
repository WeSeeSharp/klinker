import { IAppState } from "../../common";
import { SitterModel } from "../models/sitter.model";

export const getSitters = (state: IAppState): SitterModel[] => {
  const sittersState = state.sitters || {};
  return Object.keys(sittersState)
    .map(id => sittersState[id]);
};