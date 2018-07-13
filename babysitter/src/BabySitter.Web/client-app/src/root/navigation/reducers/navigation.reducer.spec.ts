import { navigationReducer } from './navigation.reducer';
import { navigationActionCreators } from '../actions';

describe('navigationReducer', () => {
  it('should open navigation when not open and toggled', () => {
    const state = navigationReducer(
      undefined,
      navigationActionCreators.toggled()
    );
    expect(state).toEqual({
      isOpen: true,
    });
  });

  it('should close navigation when opened and toggled', () => {
    const state = navigationReducer(
      { isOpen: true },
      navigationActionCreators.toggled()
    );
    expect(state).toEqual({
      isOpen: false,
    });
  });

  it('should close navigation when opened and closed', () => {
    const state = navigationReducer(
      { isOpen: true },
      navigationActionCreators.closed()
    );
    expect(state).toEqual({
      isOpen: false,
    });
  });
});
