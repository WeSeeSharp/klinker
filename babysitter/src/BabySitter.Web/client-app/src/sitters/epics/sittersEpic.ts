import { Observable } from "rxjs";
import { Action } from "redux";
import { ofType, StateObservable } from "redux-observable";
import { IAppState } from "../../AppState";
import { SitterActionCreators, SITTERS } from "../actions";
import { catchError, map, mergeMap } from "rxjs/operators";
import { IEpicDependencies } from "../../common";
import { SitterModel } from "../models";
import { of } from "rxjs/internal/observable/of";

export const getSittersEpic = (action$: Observable<Action>, state$: StateObservable<IAppState>, { baseUrl, getJSON }: IEpicDependencies): Observable<Action> =>
  action$.pipe(
    ofType(SITTERS.LOAD),
    mergeMap(() => getJSON<SitterModel[]>(`${baseUrl}/babysitters`)
      .pipe(
        map(sitters => SitterActionCreators.loadSittersSuccess(sitters)),
        catchError(err => of(SitterActionCreators.loadSittersFailed(err)))
      )),
  );