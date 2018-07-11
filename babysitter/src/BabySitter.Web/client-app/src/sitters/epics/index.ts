import { getSittersEpic, addSitterEpic } from "./sittersEpic";
import { combineEpics } from "redux-observable";

export const sittersEpics = combineEpics(getSittersEpic, addSitterEpic);