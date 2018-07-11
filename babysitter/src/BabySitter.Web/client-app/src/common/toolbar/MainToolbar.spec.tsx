import { mount } from "enzyme";
import * as React from "react";
import { MainToolbar } from "./MainToolbar";

describe("MainToolbar", () => {
  it("should toggle drawer", () => {
    let wasToggled = false;
    const toolbar = mount(<MainToolbar onToggleDrawer={() => wasToggled = true}/>);
    toolbar.find("button.drawer-toggle").simulate("click");
    expect(wasToggled).toBe(true);
  });
});