import { Observable, of } from "rxjs";

export class FakeRxJSAjax {
  private jsonResponses: {[url: string]: any } = {};

  constructor(public baseUrl: string) {
    this.getJSON = this.getJSON.bind(this);
    this.setupJSON = this.setupJSON.bind(this);
  }

  public getJSON<T>(url: string, headers?: Object): Observable<T> {
    const response = this.jsonResponses[url];
    return of(response);
  }

  public setupJSON(url: string, data: any) {
    this.jsonResponses[url] = data;
  }
}