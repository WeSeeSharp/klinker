import { createBrowserHistory } from "history";
import * as React from "react";
import { render } from "react-dom";
import { configureStore, rootReducer, Root } from "./startup";
import "./index.css";
import registerServiceWorker from "./startup/registerServiceWorker";

const history = createBrowserHistory();
const store = configureStore(rootReducer, history);
render(
  <Root history={history} store={store}/>,
  document.getElementById("root") as HTMLElement
);
registerServiceWorker();
