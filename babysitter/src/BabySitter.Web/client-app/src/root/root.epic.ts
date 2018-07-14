import { combineEpics } from 'redux-observable';
import { sittersEpics } from '../sitters/epics';

export const rootEpic = combineEpics(sittersEpics);
