import { Action } from 'redux';
import { of } from 'rxjs';
import { mergeMap, map, catchError } from 'rxjs/operators';
import { Epic } from 'redux-observable';
import { SittersActions, SittersActionTypes } from '../actions';
import { RootState } from '../../root';
import { IEpicDependencies, ajax } from '../../common';
import { SitterModel } from '../models';

export const getSittersEpic: Epic<Action, Action, RootState, IEpicDependencies> = (action$, _$, { baseUrl }) =>
  action$.ofType(SittersActionTypes.LOAD_SITTERS).pipe(
    mergeMap(() => ajax.get<SitterModel[]>(`${baseUrl}/babysitters`)),
    map(sitters => SittersActions.loadSittersSuccess(sitters)),
    catchError(() => of(SittersActions.loadSittersFailed('Failed to get sitters')))
  );
