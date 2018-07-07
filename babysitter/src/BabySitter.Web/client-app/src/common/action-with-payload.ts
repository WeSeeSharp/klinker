import { Action } from "redux";

export interface ActionWithPayload<TPayload=any> extends Action {
  payload: TPayload;
}