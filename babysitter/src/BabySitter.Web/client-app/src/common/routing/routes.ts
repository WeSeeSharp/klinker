export interface IRouteConfig {
  path: string;
  component: any;
  exact?: boolean;
  routes?: IRouteConfig[];
}

