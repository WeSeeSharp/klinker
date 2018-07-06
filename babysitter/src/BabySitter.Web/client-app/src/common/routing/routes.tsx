import { Welcome } from "../../welcome";

export interface IRouteConfig {
  path: string;
  component: (props: any) => JSX.Element;
  exact?: boolean;
  routes?: IRouteConfig[];
}

export const routes: IRouteConfig[] = [
  { path: "/", component: Welcome, routes: [] }
];