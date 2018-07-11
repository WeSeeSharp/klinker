import { SitterActionCreators } from "../actions";
import { sittersReducer } from "./sitters.reducer";
import { SitterModel } from "../models";

describe("sittersReducer", () => {
  it("should create hash of sitters when sitters loaded", () => {
    const sitters: SitterModel[] = [
      { id: 5 },
      { id: 6 },
      { id: 1 }
    ];
    const state = sittersReducer(undefined, SitterActionCreators.loadSittersSuccess(sitters));
    expect(state).toEqual({
      isAdding: false,
      5: { id: 5 },
      6: { id: 6 },
      1: { id: 1 }
    });
  });

  it("should add sitter to hash of sitters when add sitter succeeds", () => {
    const sitter: SitterModel = { id: 5 };
    const state = sittersReducer(undefined, SitterActionCreators.addSitterSuccess(sitter));
    expect(state).toEqual({
      isAdding: false,
      5: { id: 5 }
    });
  });

  it("should be adding sitter when add sitter begin", () => {
    const state = sittersReducer(undefined, SitterActionCreators.addSitterBegin());
    expect(state).toEqual({
      isAdding: true
    });
  });

  it("should not be adding sitter when add sitter cancelled", () => {
    let state = sittersReducer(undefined, SitterActionCreators.addSitterBegin());
    state = sittersReducer(state, SitterActionCreators.addSitterCancel());
    expect(state).toEqual({
      isAdding: false
    });
  });
});