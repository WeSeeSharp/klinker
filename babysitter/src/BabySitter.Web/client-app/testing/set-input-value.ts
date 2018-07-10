import { ReactWrapper } from "enzyme";

export const setInputValue = (wrapper: ReactWrapper, fieldId: string, value: string) => {
  const input: any = wrapper.find(`input#${fieldId}`);
  input.instance().value = value;
  input.simulate("change");
};