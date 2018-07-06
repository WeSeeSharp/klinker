import { ButtonBase } from "@material-ui/core";
import { connectRouter } from "connected-react-router";
import { mount } from "enzyme";
import { createMemoryHistory, History } from "history";
import * as React from "react";
import { Link } from "react-router-dom";
import { createStore } from "redux";
import { rootReducer } from "./common";
import { Root } from "./Root";
import { Welcome } from "./welcome";


it("should toggle drawer", () => {
  const history = createMemoryHistory();
  const store = configureStore(history);
  const root = mount(<Root store={store} history={history}/>);
  root.find(".drawer-toggle").findWhere(e => e.is(ButtonBase)).simulate("click");
  expect(root.find(Link).length).toBeGreaterThan(0);
});

it("should show welcome page", () => {
  const history = createMemoryHistory();
  const store = configureStore(history);
  const root = mount(<Root store={store} history={history}/>);

  expect(root.find(Welcome).length).toBe(1);
});

function configureStore(history: History) {
  return createStore(connectRouter(history)(rootReducer));
}