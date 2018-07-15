import { of } from 'rxjs';
import { ajax } from 'rxjs/ajax';
import { mergeMap, map, catchError } from 'rxjs/operators';
import { Action, AnyAction } from 'redux';
import { Epic } from 'redux-observable';
import { IRootState } from '../../root';
import { IEpicDependencies } from '../../common';
import { SITTERS, sittersActionCreators } from '../actions';
import { SitterModel } from '../models';

const failedMessage = (sitter: SitterModel) => `Failed to save sitter ${sitter.lastName}, ${sitter.firstName}`;

export const updateSitterEpic: Epic<Action, Action, IRootState, IEpicDependencies> = (action$, state$, { baseUrl }) =>
  action$.ofType(SITTERS.SAVE).pipe(
    mergeMap((action: AnyAction) =>
      ajax.put(`${baseUrl}/babysitters/${action.payload.id}`, JSON.stringify(action.payload)).pipe(
        map(() => sittersActionCreators.saveSuccess(action.payload)),
        catchError(() => of(sittersActionCreators.saveFailed(failedMessage(action.payload))))
      )
    )
  );
