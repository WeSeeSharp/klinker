import * as React from "react";
import { Route } from "react-router-dom";
import { IRouteConfig } from "./routes";

export const RouteWithSubRoutes = (route: IRouteConfig) => (
  <Route path={route.path}
         exact={route.exact}
         render={props => (<route.component {...props} routes={route.routes}/>)}
  />
);