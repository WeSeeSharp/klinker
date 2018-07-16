import { mergeMap, map, catchError } from 'rxjs/operators';
import { Epic } from 'redux-observable';
import { ajax } from 'rxjs/ajax';
import { of } from 'rxjs';
import { AnyAction } from 'redux';
import { IRootState } from '../../root';
import { IEpicDependencies } from '../../common';
import { SITTERS, sittersActionCreators } from '../actions';
import { SitterModel } from '../models';

export const addSitterEpic: Epic<AnyAction, AnyAction, IRootState, IEpicDependencies> = (
  action$,
  state$,
  { baseUrl }
) =>
  action$.ofType(SITTERS.ADD).pipe(
    mergeMap(a => ajax.post(`${baseUrl}/babysitters`, JSON.stringify(a.payload))),
    mergeMap(res => ajax.getJSON<SitterModel>(res.xhr.getResponseHeader('Location'))),
    map(sitter => sittersActionCreators.addSuccess(sitter)),
    catchError(() => of(sittersActionCreators.addFailed('Failed to add sitter')))
  );
