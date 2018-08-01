import { configure } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

configure({ adapter: new Adapter() });

const error = console.error;
console.error = (message?: any, ...optionalParams: any[]) => {
  if (!isActualError(message)) return;

  error(message, optionalParams);
};

const isActualError = (message: string) => !message.includes('Pascal') && !message.includes('Warning:');
