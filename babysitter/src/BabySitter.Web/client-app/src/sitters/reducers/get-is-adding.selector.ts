import { IRootState } from '../../root';

export const getIsAdding = ({ sitters }: IRootState) => sitters.isAdding;
