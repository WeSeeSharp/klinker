import * as React from "react";
import { mount } from "enzyme";
import { AddSitterDialog } from "./AddSitterDialog";
import { setInputValue } from "../../../testing";

describe("AddSitterDialog", () => {
  it("should save sitter", () => {
    let newSitter = null;
    const dialog = mount(<AddSitterDialog
      open={true}
      onSave={s => newSitter = s}
      onCancel={() => {
      }}/>);
    setInputValue(dialog, "firstName", "bob");
    setInputValue(dialog, "lastName", "Jack");
    dialog.find("button.save-sitter").simulate("click");
    expect(newSitter).toEqual({ firstName: "bob", lastName: "Jack" });
  });

  it("should cancel", () => {
    let wasCancelled = false;
    const dialog = mount(<AddSitterDialog
      open={true}
      onSave={() => {
      }}
      onCancel={() => wasCancelled = true}/>);
    dialog.find("button.cancel-sitter").simulate("click");
    expect(wasCancelled).toBe(true);
  });
});