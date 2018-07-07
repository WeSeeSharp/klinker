import * as React from "react";
import { mount } from "enzyme";
import { Provider } from "react-redux";
import { IAppState } from "../src/common";
import { Store } from "redux";

export const mountWithStore = (Component: any, store: Store<IAppState>) => {
  return mount(<Provider store={store}>
    <Component />
  </Provider>);
}