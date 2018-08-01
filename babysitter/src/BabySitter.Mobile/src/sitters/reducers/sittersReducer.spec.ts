import { sittersReducer } from './sittersReducer';
import { SitterModel } from '../models';
import { SittersActions } from '../actions';

describe('sittersReducer', () => {
  it('should have initial state', () => {
    // @ts-ignore
    const state = sittersReducer(null, {});
    expect(state).toEqual({
      sitters: {},
    });
  });

  it('should populate sitters', () => {
    const sitters: SitterModel[] = [{ id: 5 }, { id: 7 }];

    // @ts-ignore
    let state = sittersReducer(null, {});
    state = sittersReducer(state, SittersActions.loadSittersSuccess(sitters));
    expect(state).toEqual({
      sitters: {
        5: { id: 5 },
        7: { id: 7 },
      },
    });
  });
});
