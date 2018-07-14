import { SitterModel } from './models';

export interface ISittersState {
  isLoading?: boolean;
  error?: any;
  sitters?: {
    [id: number]: SitterModel;
  };
}
