import { createRootReducer } from './root.reducer';
import { createStore } from 'redux';

export const configureStore = () => {
  const rootReducer = createRootReducer();
  return createStore(rootReducer);
};
