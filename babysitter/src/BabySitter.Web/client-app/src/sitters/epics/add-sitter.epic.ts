import { mergeMap, map, catchError } from 'rxjs/operators';
import { Epic } from 'redux-observable';
import { of, from } from 'rxjs';
import { AnyAction } from 'redux';
import { IRootState } from '../../root';
import { IEpicDependencies, ajax } from '../../common';
import { SITTERS, sittersActionCreators } from '../actions';
import { SitterModel } from '../models';

export const addSitterEpic: Epic<AnyAction, AnyAction, IRootState, IEpicDependencies> = (
  action$,
  state$,
  { baseUrl }
) =>
  action$.ofType(SITTERS.ADD).pipe(
    mergeMap(a => ajax.post(`${baseUrl}/babysitters`, a.payload)),
    mergeMap(res => ajax.get<SitterModel>(res.xhr.getResponseHeader('Location'))),
    mergeMap(sitter => from([sittersActionCreators.addSuccess(sitter), sittersActionCreators.goTo(sitter.id)])),
    catchError(() => of(sittersActionCreators.addFailed('Failed to add sitter')))
  );
