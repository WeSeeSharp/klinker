import * as React from "react";
import { createMockStore, mountWithStore, setInputValue } from "../../testing";
import { SittersContainer } from "./SittersContainer";
import { SitterActionCreators } from "./actions";
import { AddSitterDialog } from "./add-sitter";
import { Button } from "@material-ui/core";
import { mount } from "enzyme";
import { Provider } from "react-redux";

describe("SittersContainer", () => {
  it("should get sitters", () => {
    const store = createMockStore();
    mountWithStore(SittersContainer, store);
    expect(store.getActions()).toContainEqual(SitterActionCreators.loadSitters());
  });

  it("should show list of sitters", () => {
    const store = createMockStore({
      sitters: {
        isAdding: false,
        [5]: { id: 5, firstName: "one" },
        [2]: { id: 2, firstName: "two" },
        [1]: { id: 1, firstName: "three" }
      }
    });
    const container = mountWithStore(SittersContainer, store);
    expect(container.text()).toContain("one");
    expect(container.text()).toContain("two");
    expect(container.text()).toContain("three");
  });

  it("should begin adding sitter", () => {
    const store = createMockStore();
    const container = mountWithStore(SittersContainer, store);
    container.find(Button).simulate("click");

    expect(store.getActions()).toContainEqual(SitterActionCreators.addSitterBegin());
  });

  it("should cancel adding sitter", () => {
    const store = createMockStore({ sitters: { isAdding: true } });
    const container = mountWithStore(SittersContainer, store);
    container.find("button.cancel-sitter").simulate("click");

    expect(store.getActions()).toContainEqual(SitterActionCreators.addSitterCancel());
  });

  it("should add sitter", () => {
    const store = createMockStore({ sitters: { isAdding: true } });
    const container = mountWithStore(SittersContainer, store);

    setInputValue(container, "firstName", "Jerry");
    setInputValue(container, "lastName", "Seinfeld");
    container.find("button.save-sitter").simulate("click");

    expect(container.find(AddSitterDialog).props().open).toBe(true);
    expect(store.getActions()).toContainEqual(SitterActionCreators.addSitter({
      firstName: "Jerry",
      lastName: "Seinfeld"
    }));
  });

  it("should display children", () => {
    const store = createMockStore();
    const container = mount(<Provider store={store}>
      <SittersContainer>
        <div className="jack"/>
      </SittersContainer>
    </Provider>);

    expect(container.find(".jack")).toHaveLength(1);
  });
});