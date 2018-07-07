import { mount } from "enzyme";
import { SittersList } from "./SittersList";
import * as React from "react";
import { SitterModel } from "../models/sitter.model";

it("should show sitter name", () => {
  const sitters: SitterModel[] = [
    { id: 45, firstName: "jack" },
    { id: 1, firstName: "steph" },
    { id: 2, firstName: "bob" }
  ];
  const list = mount(<SittersList sitters={sitters}/>);
  expect(list.text()).toContain("jack");
  expect(list.text()).toContain("bob");
  expect(list.text()).toContain("steph");
});