import { MockStore } from 'redux-mock-store';
import mock from 'xhr-mock';
import { IRootState } from '../../root';
import { createEpicStore, defaultBaseUrl } from '../../../testing';
import { sittersEpics } from '.';
import { sittersActionCreators } from '../actions';
import { SitterModel } from '../models';

describe('getSittersEpic', () => {
  let store: MockStore<IRootState>;

  beforeEach(() => {
    mock.setup();
    store = createEpicStore(sittersEpics);
  });

  afterEach(() => {
    mock.teardown();
  });

  it('should output load successful', done => {
    const sitters: SitterModel[] = [{ id: 5 }, { id: 3 }, { id: 1 }];
    mock.get(`${defaultBaseUrl}/babysitters`, {
      body: JSON.stringify(sitters),
    });

    store.subscribe(() => {
      if (store.getActions().length <= 1) return;
      expect(store.getActions()).toContainEqual(sittersActionCreators.loadSuccess(sitters));
      done();
    });
    store.dispatch(sittersActionCreators.load());
  });

  it('should output failed', done => {
    mock.get(`${defaultBaseUrl}/babysitters`, {
      status: 500,
    });

    store.subscribe(() => {
      if (store.getActions().length <= 1) {
        return;
      }

      expect(store.getActions()).toContainEqual(sittersActionCreators.loadFailed('Failed to get sitters'));
      done();
    });
    store.dispatch(sittersActionCreators.load());
  });
});
