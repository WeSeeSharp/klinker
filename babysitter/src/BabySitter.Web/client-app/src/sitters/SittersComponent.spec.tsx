import { Sitters } from './SittersComponent';
import { SittersListContainer } from './list/SittersListContainer';
import { createMockStore, mountWithStore } from '../../testing';
import { SelectASitter } from './detail/SelectASitterComponent';
import { SitterDetailContainer } from './detail/SitterDetailContainer';
import { AddSitterDialog } from './add-dialog/AddSitterDialogComponent';

describe('SittersComponent', () => {
  it('should show list of sitters', () => {
    const sitters = mountWithStore(Sitters, createMockStore(), '/sitters');
    expect(sitters.find(SittersListContainer)).toHaveLength(1);
  });

  it('should show select a sitter', () => {
    const sitters = mountWithStore(Sitters, createMockStore(), '/sitters');
    expect(sitters.find(SelectASitter)).toHaveLength(1);
  });

  it('should show sitter detail', () => {
    const store = createMockStore({
      sitters: {
        sitters: { 45: { id: 45 } },
      },
    });

    const sitters = mountWithStore(Sitters, store, '/sitters/45');
    expect(sitters.find(SitterDetailContainer)).toHaveLength(1);
  });

  it('should show add sitter dialog', () => {
    const store = createMockStore({
      sitters: { isAdding: true, sitters: {} },
    });

    const sitters = mountWithStore(Sitters, store);
    expect(sitters.find(AddSitterDialog).props().isOpen).toBe(true);
  });
});
