import { Observable } from "rxjs";

export interface IEpicDependencies {
  baseUrl: string;
  getJSON: <T>(url: string, headers?: Object) => Observable<T>;
}