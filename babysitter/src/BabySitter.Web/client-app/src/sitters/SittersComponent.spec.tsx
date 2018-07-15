import { Sitters } from './SittersComponent';
import { SittersListContainer } from './list/SittersListContainer';
import { createMockStore, mountWithStore, wrapWithRoute } from '../../testing';
import { SelectASitter } from './detail/SelectASitterComponent';
import { SitterDetailContainer } from './detail/SitterDetailContainer';

describe('SittersComponent', () => {
  it('should show list of sitters', () => {
    const sitters = mountWithStore(Sitters, createMockStore(), '/');
    expect(sitters.find(SittersListContainer)).toHaveLength(1);
  });

  it('should show select a sitter', () => {
    const sitters = mountWithStore(Sitters, createMockStore(), '/');
    expect(sitters.find(SelectASitter)).toHaveLength(1);
  });

  it('should show sitter detail', () => {
    const store = createMockStore({
      sitters: {
        sitters: { 45: { id: 45 } },
      },
    });

    const sitters = mountWithStore(Sitters, store, '/45');
    expect(sitters.find(SitterDetailContainer)).toHaveLength(1);
  });
});
