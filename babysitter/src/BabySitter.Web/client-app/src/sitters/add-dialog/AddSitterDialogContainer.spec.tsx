import { Dialog } from '@material-ui/core';
import { createMockStore, mountWithStore, updateField } from '../../../testing';
import { AddSitterDialogContainer } from './AddSitterDialogContainer';
import { sittersActionCreators } from '../actions';

describe('AddSitterDialogContainer', () => {
  it('should open add sitter dialog', () => {
    const store = createMockStore({
      sitters: { isAdding: true },
    });
    const container = mountWithStore(AddSitterDialogContainer, store);

    expect(container.find(Dialog).props().open).toBe(true);
  });

  it('should cancel adding sitter', () => {
    const store = createMockStore({
      sitters: { isAdding: true },
    });
    const container = mountWithStore(AddSitterDialogContainer, store);
    container.find('button#cancelAdd').simulate('click');

    expect(store.getActions()).toContainEqual(sittersActionCreators.addCancelled());
  });

  it('should add sitter', () => {
    const store = createMockStore({
      sitters: { isAdding: true },
    });

    const container = mountWithStore(AddSitterDialogContainer, store);
    updateField(container, 'firstName', 'one');
    updateField(container, 'lastName', 'hello');
    updateField(container, 'hourlyRate', 34);
    updateField(container, 'hourlyRateBetweenBedtimeAndMidnight', 8);
    updateField(container, 'hourlyRateAfterMidnight', 14);
    container.find('button#saveAdd').simulate('click');

    expect(store.getActions()).toContainEqual(
      sittersActionCreators.add({
        firstName: 'one',
        lastName: 'hello',
        hourlyRate: 34,
        hourlyRateBetweenBedtimeAndMidnight: 8,
        hourlyRateAfterMidnight: 14,
      })
    );
  });
});
