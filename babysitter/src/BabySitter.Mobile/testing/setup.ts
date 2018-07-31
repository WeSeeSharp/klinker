import { configure } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

configure({ adapter: new Adapter() });

const error = console.error;
console.error = (message?: any, ...optionalParams: any[]) => {
  if (message.indexOf('Pascal') > -1)
      return;

  if (message.indexOf('Warning: The tag') > -1)
      return;

  error(message, optionalParams);
};