import { ReactWrapper } from 'enzyme';

export const updateField = (container: ReactWrapper, fieldName: string, value: any) => {
  const input: any = container.find(`input#${fieldName}`).getDOMNode();
  input.value = value;
  container.find(`input#${fieldName}`).simulate('change', { currentTarget: { value } });
  container.update();
};
