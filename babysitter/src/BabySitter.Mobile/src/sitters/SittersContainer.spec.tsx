import * as React from 'react';
import { SittersContainer } from './SittersContainer';
import { createMockStore, mountWithStore } from '../../testing';
import { SittersActions } from './actions';
import { IRootState } from '../root';

describe('SittersContainer', () => {
  it('should load sitters', () => {
    const store = createMockStore();
    const container = mountWithStore(SittersContainer, store);

    expect(store.getActions()).toContainEqual(SittersActions.loadSitters());
  });

  it('should have sitters', () => {
    const store = createMockStore({
      sitters: {
        sitters: {
          [4]: { id: 4, firstName: 'Bobby', lastName: 'Joe' },
          [5]: { id: 5, firstName: 'Jack', lastName: 'Jill' },
          [2]: { id: 2, firstName: 'Steph', lastName: 'Miller' },
        },
      },
    });

    const container = mountWithStore(SittersContainer, store);
    expect(container.text()).toContain('Joe, Bobby');
    expect(container.text()).toContain('Jill, Jack');
    expect(container.text()).toContain('Miller, Steph');
  });
});
