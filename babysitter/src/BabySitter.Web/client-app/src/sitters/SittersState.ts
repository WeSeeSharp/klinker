import { SitterModel } from "./models/sitter.model";

export interface ISittersState {
  [id: number]: SitterModel;
}