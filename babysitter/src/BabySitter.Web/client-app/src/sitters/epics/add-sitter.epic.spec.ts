import createMockStore, { MockStore } from 'redux-mock-store';
import mock from 'xhr-mock';
import { IRootState } from '../../root';
import { createEpicStore, defaultBaseUrl } from '../../../testing';
import { sittersEpics } from '.';
import { sittersActionCreators } from '../actions';

describe('addSitterEpic', () => {
  let store: MockStore<IRootState>;

  beforeEach(() => {
    mock.setup();
    store = createEpicStore(sittersEpics);
  });

  afterEach(() => {
    mock.teardown();
  });

  it('should post sitter to api and output new sitter', done => {
    let requestBody: any = null;
    mock.post(`${defaultBaseUrl}/babysitters`, (req, res) => {
      requestBody = req.body();
      res.header('Location', `${defaultBaseUrl}/babysitters/6`);
      res.status(201);
      return res;
    });

    mock.get(`${defaultBaseUrl}/babysitters/6`, {
      body: JSON.stringify({ id: 6, firstName: 'bob' }),
    });

    store.subscribe(() => {
      if (store.getActions().length <= 1) return;

      expect(requestBody).toBe(JSON.stringify({ firstName: 'bob' }));
      expect(store.getActions()).toContainEqual(sittersActionCreators.addSuccess({ id: 6, firstName: 'bob' }));
      done();
    });
    store.dispatch(sittersActionCreators.add({ firstName: 'bob' }));
  });

  it('should output failed add', done => {
    mock.post(`${defaultBaseUrl}/babysitters`, {
      status: 500,
    });

    store.subscribe(() => {
      if (store.getActions().length <= 1) return;

      expect(store.getActions()).toContainEqual(sittersActionCreators.addFailed('Failed to add sitter'));
      done();
    });
    store.dispatch(sittersActionCreators.add({}));
  });
});
