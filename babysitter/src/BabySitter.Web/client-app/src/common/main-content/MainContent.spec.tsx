import { mount } from "enzyme";
import * as React from "react";
import { MainContent } from "./MainContent";

describe("MainContent", () => {
  it("should show children", () => {
    const content = mount(<MainContent>hello</MainContent>);
    expect(content.text()).toContain("hello");
  });
});