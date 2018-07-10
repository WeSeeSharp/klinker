import xhrMock from 'xhr-mock';
import { StateObservable } from "redux-observable";
import { SitterActionCreators } from "../actions";
import { addSitterEpic, getSittersEpic } from "./sittersEpic";
import { Action } from "redux";
import { IAppState } from "../../AppState";
import { ActionWithPayload, IEpicDependencies } from "../../common";
import { Subject } from "rxjs";
import { baseUrl } from "../../../testing";
import MockRequest from "xhr-mock/lib/MockRequest";
import MockResponse from "xhr-mock/lib/MockResponse";

let action$: Subject<Action>;
let state$: StateObservable<IAppState>;
let dependencies: IEpicDependencies;

beforeEach(() => {
  xhrMock.setup();
  action$ = new Subject<ActionWithPayload<any>>();
  state$ = new StateObservable<IAppState>(new Subject<IAppState>(), {});
  dependencies = { baseUrl };
});

afterEach(() => {
  xhrMock.teardown();
})

it("should get sitters from api", done => {
  xhrMock.get(`${baseUrl}/babysitters`, {
    body: JSON.stringify([])
  });
  getSittersEpic(action$, state$, dependencies)
    .subscribe(a => {
      expect(a).toEqual(SitterActionCreators.loadSittersSuccess([]));
      done();
    });
  action$.next(SitterActionCreators.loadSitters());
});

it("should fail to get sitters from api", done => {
  xhrMock.get(`${baseUrl}/babysitters`, {
    status: 400,
    body: 'nope'
  });
  getSittersEpic(action$, state$, dependencies)
    .subscribe(a => {
      expect(a).toEqual(SitterActionCreators.loadSittersFailed("nope"));
      done();
    });
  action$.next(SitterActionCreators.loadSitters());
});

it('should post sitter to api', done => {
  let requestBody: any;
  xhrMock.post(`${baseUrl}/babysitters`, (req:MockRequest, res: MockResponse) => {
    res.status(201);
    res.headers({
      ...res.headers(),
      'location': `${baseUrl}/babysitters`
    });
    requestBody = req.body();
    return res;
  });

  xhrMock.get(`${baseUrl}/babysitters`, {
    body: JSON.stringify({ id: 5, firstName: 'bob', lastName: 'jack' })
  });
  addSitterEpic(action$.asObservable(), state$, dependencies)
    .subscribe(a => {
      expect(requestBody).toEqual(JSON.stringify({ firstName: 'bob', lastName: 'jack' }));
      expect(a).toEqual(SitterActionCreators.addSitterSuccess({ id: 5, firstName: 'bob', lastName: 'jack' }))
      done();
    });
  action$.next(SitterActionCreators.addSitter({ firstName: 'bob', lastName: 'jack' }))
});