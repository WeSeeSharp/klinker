import { createMockStore, mountWithStore, wrapWithRoute, updateField } from '../../../testing';
import { SitterDetailContainer } from './SitterDetailContainer';
import { ReactWrapper } from 'enzyme';
import { sittersActionCreators } from '../actions';

describe('SitterDetailContainer', () => {
  it('should show sitter details', () => {
    const store = createMockStore({
      sitters: {
        sitters: {
          43: {
            id: 43,
            firstName: 'Stacey',
            lastName: 'Jack',
            hourlyRate: 23,
            hourlyRateAfterMidnight: 89,
            hourlyRateBetweenBedtimeAndMidnight: 8,
          },
        },
      },
    });

    const container = mountWithStore(wrapWithRoute(SitterDetailContainer, '/:id'), store, '/43');
    expect(container.find('input#firstName').props().value).toBe('Stacey');
    expect(container.find('input#lastName').props().value).toBe('Jack');
    expect(container.find('input#hourlyRate').props().value).toBe(23);
    expect(container.find('input#hourlyRateBetweenBedtimeAndMidnight').props().value).toBe(8);
    expect(container.find('input#hourlyRateAfterMidnight').props().value).toBe(89);
  });

  it('should save updated sitter', () => {
    const store = createMockStore({
      sitters: {
        sitters: {
          43: {
            id: 43,
            firstName: 'Stacey',
            lastName: 'Jack',
            hourlyRate: 23,
            hourlyRateAfterMidnight: 89,
            hourlyRateBetweenBedtimeAndMidnight: 8,
          },
        },
      },
    });

    const container = mountWithStore(wrapWithRoute(SitterDetailContainer, '/:id'), store, '/43');
    updateField(container, 'firstName', 'Bob');
    updateField(container, 'lastName', 'Jill');
    updateField(container, 'hourlyRate', 45);
    updateField(container, 'hourlyRateBetweenBedtimeAndMidnight', 77);
    updateField(container, 'hourlyRateAfterMidnight', 12);
    clickUpdate(container);
    expect(store.getActions()).toContainEqual(
      sittersActionCreators.save({
        id: 43,
        firstName: 'Bob',
        lastName: 'Jill',
        hourlyRate: 45,
        hourlyRateBetweenBedtimeAndMidnight: 77,
        hourlyRateAfterMidnight: 12,
      })
    );
  });

  function clickUpdate(container: ReactWrapper) {
    container.find('button#update').simulate('click');
  }
});
