import { INavigationState } from './navigation/INavigationState';
import { ISittersState } from '../sitters/sitters.state';

export interface IRootState {
  navigation?: INavigationState;
  sitters?: ISittersState;
}
