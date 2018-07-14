import { createEpicMiddleware } from 'redux-observable';
import { createMockStore } from './create-mock-store';
import { MockStore } from 'redux-mock-store';
import { IRootState } from '../src/root';

export const defaultBaseUrl = 'https://localhost:5001';
export const createEpicStore = (
  epics,
  baseUrl: string = defaultBaseUrl
): MockStore<IRootState> => {
  const middleware = createEpicMiddleware({
    dependencies: {
      baseUrl,
    },
  });
  const store = createMockStore(undefined, [middleware]);
  middleware.run(epics);
  return store;
};
