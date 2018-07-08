import { Observable } from "rxjs";
import { Action } from "redux";
import { ofType, StateObservable } from "redux-observable";
import { IAppState } from "../../AppState";
import { SitterActionCreators, SITTERS } from "../actions";
import { map, mergeMap } from "rxjs/operators";
import { IEpicDependencies } from "../../common";
import { SitterModel } from "../models";

export const getSittersEpic = (action$: Observable<Action>, state$: StateObservable<IAppState>, { baseUrl, getJSON }: IEpicDependencies): Observable<Action> =>
  action$.pipe(
    ofType(SITTERS.LOAD),
    mergeMap(() => getJSON<SitterModel[]>(`${baseUrl}/sitters`)),
    map(sitters => SitterActionCreators.loadSittersSuccess(sitters))
  );