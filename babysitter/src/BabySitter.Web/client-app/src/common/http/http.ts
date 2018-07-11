import { ajax, AjaxResponse } from "rxjs/ajax";
import { Observable } from "rxjs/internal/Observable";

export const http = {
  get: function <T>(url: string) {
    return ajax.getJSON<T>(url);
  },
  post: function <T>(url: string, body: T, headers?: Object): Observable<AjaxResponse> {
    return ajax.post(url, JSON.stringify(body), {...headers, 'content-type': 'application/json' });
  }
};