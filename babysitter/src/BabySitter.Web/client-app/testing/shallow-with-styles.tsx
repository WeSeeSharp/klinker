import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';

export const shallowWithStyles = (Component: any, props: any = {}) => {
  const shallow = createShallow({
    untilSelector: Component,
  });

  return shallow(<Component {...props} />);
};
