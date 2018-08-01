import { combineEpics } from 'redux-observable';
import { sittersEpics } from '../sitters';

export const rootEpic = combineEpics(sittersEpics);
