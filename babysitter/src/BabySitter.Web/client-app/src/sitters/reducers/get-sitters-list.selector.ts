import { IRootState } from '../../root';

export const getSittersList = ({ sitters }: IRootState) =>
  Object.keys(sitters.sitters).map(key => sitters.sitters[key]);
