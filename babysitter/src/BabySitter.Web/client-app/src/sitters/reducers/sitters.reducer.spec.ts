import { sittersReducer } from './sitters.reducer';
import { sittersActionCreators } from '../actions';
import { SitterModel } from '../models';

describe('sittersReducer', () => {
  it('should be loading', () => {
    const state = sittersReducer(undefined, sittersActionCreators.load());
    expect(state.isLoading).toBe(true);
  });

  it('should populate sitters', () => {
    const sitters: SitterModel[] = [
      { id: 5, firstName: 'bob' },
      { id: 9, firstName: 'jack' },
      { id: 3, firstName: 'john' },
    ];
    const state = sittersReducer(
      undefined,
      sittersActionCreators.loadSuccess(sitters)
    );
    expect(state.isLoading).toBe(false);
    expect(state.sitters).toEqual({
      5: { id: 5, firstName: 'bob' },
      9: { id: 9, firstName: 'jack' },
      3: { id: 3, firstName: 'john' },
    });
  });

  it('should not be loading when sitters loaded successfully', () => {
    let state = sittersReducer(undefined, sittersActionCreators.load());
    state = sittersReducer(state, sittersActionCreators.loadSuccess([]));
    expect(state.isLoading).toBe(false);
  });

  it('should not be loading when sitters load fails', () => {
    let state = sittersReducer(undefined, sittersActionCreators.load());
    state = sittersReducer(state, sittersActionCreators.loadFailed('idk'));
    expect(state.isLoading).toBe(false);
  });

  it('should have load error', () => {
    const state = sittersReducer(
      undefined,
      sittersActionCreators.loadFailed('nope')
    );
    expect(state.error).toBe('nope');
  });
});
