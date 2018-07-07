import { ISittersState } from "../sitters";

export interface IAppState {
  isOpen?: boolean;
  sitters?: ISittersState;
}