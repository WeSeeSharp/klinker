import { Observable, of, throwError } from "rxjs";

export class FakeRxJSAjax {
  private jsonResponses: {[url: string]: any } = {};
  private errorResponses: {[url: string]: any } = {};

  constructor(public baseUrl: string) {
    this.getJSON = this.getJSON.bind(this);
    this.setupJSON = this.setupJSON.bind(this);
  }

  public getJSON<T>(url: string, headers?: Object): Observable<T> {
    if (this.errorResponses.hasOwnProperty(url)) {
      const error = this.errorResponses[url];
      return throwError(error);
    }
    const response = this.jsonResponses[url];
    return of(response);
  }

  public setupJSON(url: string, data: any) {
    this.jsonResponses[url] = data;
  }

  public setupFailure(url: string, error: any = 'Not good') {
    this.errorResponses[url] = error;
  }
}