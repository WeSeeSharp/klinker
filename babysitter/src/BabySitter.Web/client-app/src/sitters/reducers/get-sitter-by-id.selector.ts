import { IRootState } from '../../root';

export const getSitterById = ({ sitters: { sitters } }: IRootState, id: number) => sitters[id];
