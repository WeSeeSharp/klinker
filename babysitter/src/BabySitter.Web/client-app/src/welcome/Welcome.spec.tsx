import React from 'react';
import { mount } from 'enzyme';
import { Welcome } from './Welcome';

describe('Welcome', () => {
  it('should show welcome message', () => {
    const welcome = mount(<Welcome />);
    expect(welcome.text()).toContain('Welcome');
  });
});
