import { sittersReducer } from './sitters.reducer';
import { sittersActionCreators } from '../actions';
import { SitterModel } from '../models';

describe('sittersReducer', () => {
  it('should be loading when load sitters', () => {
    const state = sittersReducer(undefined, sittersActionCreators.load());
    expect(state.isLoading).toBe(true);
  });

  it('should populate sitters', () => {
    const sitters: SitterModel[] = [
      { id: 5, firstName: 'bob' },
      { id: 9, firstName: 'jack' },
      { id: 3, firstName: 'john' },
    ];
    const state = sittersReducer(undefined, sittersActionCreators.loadSuccess(sitters));
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
    const state = sittersReducer(undefined, sittersActionCreators.loadFailed('nope'));
    expect(state.error).toBe('nope');
  });

  it('should be loading when save sitter', () => {
    const state = sittersReducer(undefined, sittersActionCreators.save({ id: 55 }));
    expect(state.isLoading).toBe(true);
  });

  it('should update sitter when save successful', () => {
    let state = sittersReducer(undefined, sittersActionCreators.loadSuccess([{ id: 6 }]));
    state = sittersReducer(state, sittersActionCreators.save({ id: 6 }));

    state = sittersReducer(state, sittersActionCreators.saveSuccess({ id: 6, firstName: 'bob' }));
    expect(state.sitters[6]).toEqual({ id: 6, firstName: 'bob' });
    expect(state.isLoading).toBe(false);
  });

  it('should have error from save', () => {
    let state = sittersReducer(undefined, sittersActionCreators.save({ id: 66 }));

    state = sittersReducer(state, sittersActionCreators.saveFailed('Failed'));
    expect(state.error).toBe('Failed');
  });

  it('should be adding sitter', () => {
    const state = sittersReducer(undefined, sittersActionCreators.addBegin());
    expect(state.isAdding).toBe(true);
  });

  it('should not be adding sitter after cancelling add', () => {
    let state = sittersReducer(undefined, sittersActionCreators.addBegin());
    state = sittersReducer(state, sittersActionCreators.addCancelled());
    expect(state.isAdding).toBe(false);
  });

  it('should be loading when sitter added', () => {
    const state = sittersReducer(undefined, sittersActionCreators.add({}));
    expect(state.isLoading).toBe(true);
  });

  it('should not be loading or adding when sitter added successfully', () => {
    let state = sittersReducer(undefined, sittersActionCreators.addBegin());
    state = sittersReducer(state, sittersActionCreators.add({}));

    state = sittersReducer(state, sittersActionCreators.addSuccess({ id: 7 }));
    expect(state.isAdding).toBe(false);
    expect(state.isLoading).toBe(false);
    expect(state.sitters[7]).toEqual({ id: 7 });
  });

  it('should not be loading when add sitter failed', () => {
    let state = sittersReducer(undefined, sittersActionCreators.addBegin());
    state = sittersReducer(state, sittersActionCreators.add({}));

    state = sittersReducer(state, sittersActionCreators.addFailed('Not good'));
    expect(state.isLoading).toBe(false);
    expect(state.isAdding).toBe(true);
    expect(state.error).toBe('Not good');
  });
});
