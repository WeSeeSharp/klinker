import { IRootState } from '../../root.state';

export const getIsOpen = ({ navigation }: IRootState) => navigation.isOpen;
