import { mount, ReactWrapper } from "enzyme";
import * as React from "react";
import { Link, LinkProps, MemoryRouter } from "react-router-dom";
import { NavigationDrawer } from "./NavigationDrawer";
import { Drawer } from "@material-ui/core";

describe("NavigationDrawer", () => {
  let wasClosed = false;

  it("should show links when open", () => {
    const navigation = mountOpen();
    const links = navigation.find(Link);
    expect(hasLink("Sitters", links)).toBe(true);
    expect(hasLink("Shifts", links)).toBe(true);
    expect(hasLink("Home", links)).toBe(true);
  });

  it("should hide links when close", () => {
    const navigation = mountClosed();
    const links = navigation.find(Link);
    expect(hasLink("Sitters", links)).toBe(false);
    expect(hasLink("Shifts", links)).toBe(false);
    expect(hasLink("Home", links)).toBe(false);
  });

  it("should notify when drawer is closed", () => {
    const navigation = mountOpen();
    navigation.find(Drawer).props().onClose({});
    expect(wasClosed).toBe(true);
  });

  it("should close drawer when link is clicked", () => {
    const navigation = mountOpen();
    navigation.find(Link).first().simulate("click");
    expect(wasClosed).toBe(true);
  });

  function hasLink(text: string, links: ReactWrapper<Readonly<LinkProps>>) {
    return links.someWhere(l => l.text().includes(text));
  }

  function mountOpen() {
    return mount(
      <MemoryRouter>
        <NavigationDrawer open={true} onClose={() => wasClosed = true}/>
      </MemoryRouter>
    );
  }

  function mountClosed() {
    return mount(
      <MemoryRouter>
        <NavigationDrawer open={false} onClose={() => wasClosed = true}/>
      </MemoryRouter>
    );
  }
});