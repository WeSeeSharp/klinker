import { createMockStore, mountWithStore } from '../../../testing';
import { RootNavigationContainer } from './RootNavigationContainer';
import { Drawer } from '@material-ui/core';
import { navigationActionCreators } from './actions';

describe('RootNavigationContainer', () => {
  it('should show main navigation', () => {
    const store = createMockStore({ navigation: { isOpen: true } });
    const container = mountWithStore(RootNavigationContainer, store);
    expect(container.find(Drawer).props().open).toBe(true);
  });

  it('should close main navigation', () => {
    const store = createMockStore();
    const container = mountWithStore(RootNavigationContainer, store);
    container
      .find(Drawer)
      .props()
      .onClose();

    expect(store.getActions()).toContainEqual(
      navigationActionCreators.closed()
    );
  });
});
