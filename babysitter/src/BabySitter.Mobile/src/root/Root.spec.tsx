import React from 'react';
import mock from 'xhr-mock';
import { render } from 'enzyme';
import { Root } from './Root';

describe('Root', () => {
  beforeEach(() => {
    mock.setup();
  });

  afterEach(() => {
    mock.reset();
  });

  it('should show sitters', () => {
    const root = render(<Root />);
    expect(root.find('[testID=sitters-screen]')).toHaveLength(1);
  });
});
