import { createEpicMiddleware } from 'redux-observable';
import { createMockStore } from './create-mock-store';
import { MockStore } from 'redux-mock-store';
import { RootState } from '../src/root';

export const defaultBaseUrl = 'https://localhost:5001';
export const createEpicStore = (epics: any, baseUrl: string = defaultBaseUrl): MockStore<RootState> => {
  const middleware = createEpicMiddleware({
    dependencies: {
      baseUrl,
    },
  });
  const store = createMockStore(undefined, [middleware]);
  middleware.run(epics);
  return store;
};
