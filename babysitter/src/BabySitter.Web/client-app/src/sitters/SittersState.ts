import { SitterModel } from "./models";

export interface ISittersState {
  isAdding: boolean;
  [id: number]: SitterModel;
}