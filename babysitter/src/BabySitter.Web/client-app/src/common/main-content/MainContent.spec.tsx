import { shallow } from "enzyme";
import * as React from "react";
import { MainContent } from "./MainContent";

it("should show children", () => {
  const content = shallow(<MainContent>hello</MainContent>);
  expect(content.text()).toContain("hello");
});