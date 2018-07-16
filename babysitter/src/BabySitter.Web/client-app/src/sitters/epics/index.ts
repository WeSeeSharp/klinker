import { combineEpics } from 'redux-observable';
import { getSittersEpic } from './get-sitters.epic';
import { updateSitterEpic } from './update-sitter.epic';
import { addSitterEpic } from './add-sitter.epic';

export const sittersEpics = combineEpics(getSittersEpic, updateSitterEpic, addSitterEpic);
