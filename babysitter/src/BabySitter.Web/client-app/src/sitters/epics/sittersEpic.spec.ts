import { FakeRxJSAjax } from "../../../testing";
import { StateObservable } from "redux-observable";
import { SitterActionCreators } from "../actions";
import { getSittersEpic } from "./sittersEpic";
import { Action } from "redux";
import { IAppState } from "../../common";
import { IEpicDependencies } from "../../epic-dependencies";
import { Subject } from "rxjs";

let fakeAjax: FakeRxJSAjax;
let action$: Subject<Action>;
let state$: StateObservable<IAppState>;
let dependencies: IEpicDependencies;

beforeEach(() => {
  fakeAjax = new FakeRxJSAjax("https://what.com");
  action$ = new Subject<Action>();
  state$ = new StateObservable<IAppState>(new Subject<IAppState>(), {});
  dependencies = {
    getJSON: fakeAjax.getJSON,
    baseUrl: fakeAjax.baseUrl
  };
});

it("should get sitters from api", done => {
  fakeAjax.setupJSON(`${fakeAjax.baseUrl}/sitters`, []);
  getSittersEpic(action$, state$, dependencies)
    .subscribe(a => {
      expect(a).toEqual(SitterActionCreators.loadSittersSuccess([]));
      done();
    });
  action$.next(SitterActionCreators.loadSitters());
});