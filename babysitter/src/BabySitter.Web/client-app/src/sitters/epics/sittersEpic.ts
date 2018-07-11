import { Observable, of } from "rxjs";
import { AjaxError } from "rxjs/ajax";
import { Action, AnyAction } from "redux";
import { ofType, StateObservable } from "redux-observable";
import { IAppState } from "../../AppState";
import { SitterActionCreators, SITTERS } from "../actions";
import { catchError, map, mergeMap } from "rxjs/operators";
import { IEpicDependencies, http } from "../../common";
import { SitterModel } from "../models";

export const getSittersEpic = (action$: Observable<Action>, state$: StateObservable<IAppState>, { baseUrl}: IEpicDependencies): Observable<Action> =>
  action$.pipe(
    ofType(SITTERS.LOAD),
    mergeMap(() => http.get<SitterModel[]>(`${baseUrl}/babysitters`)
      .pipe(
        map(sitters => SitterActionCreators.loadSittersSuccess(sitters)),
        catchError((err: AjaxError) => of(SitterActionCreators.loadSittersFailed(err.xhr.responseText)))
      )),
  );

export const addSitterEpic = (action$: Observable<AnyAction>, state$: StateObservable<IAppState>, { baseUrl }: IEpicDependencies): Observable<Action> =>
  action$.pipe(
    ofType(SITTERS.ADD),
    mergeMap(a => http.post(`${baseUrl}/babysitters`, a.payload, { 'content-type': 'application/json'})
      .pipe(
        mergeMap(res => http.get<SitterModel>(res.xhr.getResponseHeader('Location') || '')
          .pipe(
            map(s => SitterActionCreators.addSitterSuccess(s))
          ))
      ))
  );