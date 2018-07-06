import { shallow } from "enzyme";
import * as React from "react";
import { MainToolbar } from "./MainToolbar";

it('should toggle drawer', () => {
  let wasToggled = false;
  const toolbar = shallow(<MainToolbar onToggleDrawer={() => wasToggled = true}/>);
  toolbar.find('.drawer-toggle').simulate('click');
  expect(wasToggled).toBe(true);
});