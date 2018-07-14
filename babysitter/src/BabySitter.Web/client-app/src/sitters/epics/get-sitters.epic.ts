import { Action } from 'redux';
import { of } from 'rxjs';
import { ajax } from 'rxjs/ajax';
import { mergeMap, map, catchError } from 'rxjs/operators';
import { Epic } from 'redux-observable';
import { SITTERS, sittersActionCreators } from '../actions';
import { IRootState } from '../../root';
import { IEpicDependencies } from '../../common';
import { SitterModel } from '../models';

export const getSittersEpic: Epic<
  Action,
  Action,
  IRootState,
  IEpicDependencies
> = (action$, state$, { baseUrl }) =>
  action$.ofType(SITTERS.LOAD).pipe(
    mergeMap(() => ajax.getJSON<SitterModel[]>(`${baseUrl}/babysitters`)),
    map(sitters => sittersActionCreators.loadSuccess(sitters)),
    catchError(() =>
      of(sittersActionCreators.loadFailed('Failed to get sitters'))
    )
  );
