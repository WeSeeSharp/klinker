import { mount } from "enzyme";
import { SittersList } from "./SittersList";
import * as React from "react";
import { SitterModel } from "../models";

it("should show sitter name", () => {
  const sitters: SitterModel[] = [
    { id: 45, firstName: "jack" },
    { id: 1, firstName: "steph" },
    { id: 2, firstName: "bob" }
  ];
  const list = mount(<SittersList sitters={sitters} onAddSitter={() => {
  }}/>);
  expect(list.text()).toContain("jack");
  expect(list.text()).toContain("bob");
  expect(list.text()).toContain("steph");
});

it("should begin add", () => {
  let didAdd = false;
  const list = mount(<SittersList sitters={[]} onAddSitter={() => didAdd = true}/>);
  list.find("button.add-sitter").simulate("click");
  expect(didAdd).toBe(true);
});