import { ButtonBase, Drawer } from "@material-ui/core";
import { connectRouter } from "connected-react-router";
import { mount, ReactWrapper } from "enzyme";
import { createMemoryHistory, History } from "history";
import * as React from "react";
import { Link } from "react-router-dom";
import { createStore } from "redux";
import { rootReducer } from "./common";
import { Root } from "./Root";
import { Welcome } from "./welcome";

let root: ReactWrapper;

beforeEach(() => {
  const history = createMemoryHistory();
  const store = configureStore(history);
  root = mount(<Root store={store} history={history}/>);
});

it("should toggle drawer", () => {
  toggleDrawer();
  expect(root.find(Link).length).toBeGreaterThan(0);
});

it("should show welcome page", () => {
  expect(root.find(Welcome).length).toBe(1);
});

it("should close drawer when clicked elsewhere", () => {
  toggleDrawer();
  clickNavigationLink();
  expect(root.find(Drawer).props().open).toBe(false);
});

function toggleDrawer() {
  root.find(".drawer-toggle").findWhere(e => e.is(ButtonBase)).simulate("click");
  root.update();
}

function clickNavigationLink() {
  root.find(Drawer).props().onClose();
  root.update();
}

function configureStore(history: History) {
  return createStore(connectRouter(history)(rootReducer));
}