import { SitterActionCreators } from "../actions";
import { sittersReducer } from "./sitters.reducer";
import { SitterModel } from "../models";

it("should create hash of sitters", () => {
  const sitters: SitterModel[] = [
    { id: 5 },
    { id: 6 },
    { id: 1 }
  ];
  const state = sittersReducer(undefined, SitterActionCreators.loadSittersSuccess(sitters));
  expect(state).toEqual({
    [5]: { id: 5 },
    [6]: { id: 6 },
    [1]: { id: 1 }
  });
});