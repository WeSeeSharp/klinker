import { createMockStore, mountWithStore } from '../../../testing';
import { SittersListContainer } from './SittersListContainer';
import { sittersActionCreators } from '../actions';

describe('SittersListContainer', () => {
  it('should show sitter names', () => {
    const store = createMockStore({
      sitters: {
        sitters: {
          5: { id: 5, firstName: 'jack', lastName: 'bob' },
          4: { id: 4, firstName: 'guy', lastName: 'science' },
          3: { id: 3, firstName: 'bill', lastName: 'nye' },
        },
      },
    });

    const container = mountWithStore(SittersListContainer, store);
    expect(container.text()).toContain('bob, jack');
    expect(container.text()).toContain('science, guy');
    expect(container.text()).toContain('nye, bill');
  });

  it('should load sitters', () => {
    const store = createMockStore();

    mountWithStore(SittersListContainer, store);
    expect(store.getActions()).toContainEqual(sittersActionCreators.load());
  });
});
