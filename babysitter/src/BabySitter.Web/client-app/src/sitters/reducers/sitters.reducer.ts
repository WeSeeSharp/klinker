import { ISittersState } from "../SittersState";
import { ActionWithPayload, createReducerHash } from "../../common";
import { SitterModel } from "../models";
import { SITTERS } from "../actions";

const initialState: ISittersState = {
  isAdding: false
};

const reduceLoadSuccess = (state: ISittersState = initialState, action: ActionWithPayload<SitterModel[]>) => ({
  ...state,
  ...action.payload.reduce((acc, item) => {
    acc[item.id] = item;
    return acc;
  }, {})
});

const reduceAddBegin = (state: ISittersState = initialState) => ({
  ...state,
  isAdding: true
});

const reduceAddCancel = (state: ISittersState = initialState) => ({
  ...state,
  isAdding: false
});

const reduceAddSuccess = (state: ISittersState = initialState, action: ActionWithPayload<SitterModel>) => ({
  ...state,
  [action.payload.id]: action.payload,
  isAdding: false
});

export const sittersReducer = createReducerHash({
  [SITTERS.LOAD_SUCCESS]: reduceLoadSuccess,
  [SITTERS.ADD_BEGIN]: reduceAddBegin,
  [SITTERS.ADD_CANCEL]: reduceAddCancel,
  [SITTERS.ADD_SUCCESS]: reduceAddSuccess
}, initialState);