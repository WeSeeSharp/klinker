import { IAppState } from "../../AppState";
import { SitterModel } from "../models";

export const getSitters = (state: IAppState): SitterModel[] => {
  const sittersState = state.sitters || {};
  return Object.keys(sittersState)
    .filter(key => typeof sittersState[key] === 'object')
    .map(id => sittersState[id]);
};