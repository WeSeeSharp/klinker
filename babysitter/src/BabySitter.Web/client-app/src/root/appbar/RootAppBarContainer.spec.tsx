import { createMockStore, mountWithStore } from '../../../testing';
import { RootAppBarContainer } from './RootAppBarContainer';
import { navigationActionCreators } from '../navigation/actions';

describe('RootAppBarContainer', () => {
  it('should toggle navigation menu', () => {
    const store = createMockStore();
    const container = mountWithStore(RootAppBarContainer, store);
    container.find('button').simulate('click');
    expect(store.getActions()).toContainEqual(
      navigationActionCreators.toggled()
    );
  });
});
