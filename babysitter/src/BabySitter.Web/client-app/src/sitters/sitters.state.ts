import { SitterModel } from './models';

export interface ISittersState {
  isLoading?: boolean;
  isAdding?: boolean;
  error?: any;
  sitters?: {
    [id: number]: SitterModel;
  };
}
