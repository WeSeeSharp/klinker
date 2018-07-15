import mock from 'xhr-mock';
import { MockStore } from 'redux-mock-store';
import { IRootState } from '../../root';
import { defaultBaseUrl, createEpicStore } from '../../../testing';
import { SitterModel } from '../models';
import { sittersActionCreators } from '../actions';
import { sittersEpics } from '.';

describe('updateSitterEpic', () => {
  let store: MockStore<IRootState>;

  beforeEach(() => {
    mock.setup();
    store = createEpicStore(sittersEpics);
  });

  afterEach(() => {
    mock.teardown();
  });

  it('should output save successful', done => {
    const updatedSitter: SitterModel = {
      id: 8,
      firstName: 'bob',
    };
    mock.put(`${defaultBaseUrl}/babysitters/8`, {
      body: JSON.stringify(updatedSitter),
    });

    store.subscribe(() => {
      if (store.getActions().length <= 1) return;

      expect(store.getActions()).toContainEqual(sittersActionCreators.saveSuccess(updatedSitter));
      done();
    });
    store.dispatch(sittersActionCreators.save(updatedSitter));
  });

  it('should output failed', done => {
    const updatedSitter: SitterModel = {
      id: 8,
      firstName: 'bob',
      lastName: 'Jack',
    };
    mock.put(`${defaultBaseUrl}/babysitters/8`, {
      status: 500,
    });

    store.subscribe(() => {
      if (store.getActions().length <= 1) return;

      expect(store.getActions()).toContainEqual(sittersActionCreators.saveFailed('Failed to save sitter Jack, bob'));
      done();
    });
    store.dispatch(sittersActionCreators.save(updatedSitter));
  });
});
