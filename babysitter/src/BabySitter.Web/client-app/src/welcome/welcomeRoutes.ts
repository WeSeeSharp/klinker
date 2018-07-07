import { Welcome } from "./index";
import { IRouteConfig } from "../common";

export const welcomeRoutes: IRouteConfig[] = [
  { path: "/", component: Welcome, routes: [] }
];