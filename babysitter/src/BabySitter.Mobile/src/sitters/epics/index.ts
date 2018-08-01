import { combineEpics } from 'redux-observable';
import { getSittersEpic } from './get-sitters.epic';

export const sittersEpics = combineEpics(getSittersEpic);
