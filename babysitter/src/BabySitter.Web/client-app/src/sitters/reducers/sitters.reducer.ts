import { ISittersState } from "../SittersState";
import { ActionWithPayload } from "../../common";
import { SitterModel } from "../models";
import { SITTERS } from "../actions";
import { createReducerHash } from "../../common";

const reduceLoadSuccess = (state: ISittersState = {}, action: ActionWithPayload<SitterModel[]>) => ({
  ...state,
  ...action.payload.reduce((acc, item) => {
    acc[item.id] = item;
    return acc;
  }, {})
});

export const sittersReducer = createReducerHash({
  [SITTERS.LOAD_SUCCESS]: reduceLoadSuccess
}, {});