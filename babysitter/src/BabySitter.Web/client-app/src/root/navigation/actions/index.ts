export const NAVIGATION = {
  CLOSED: '[Navigation] Closed',
  TOGGLED: '[Navigation] Toggled',
};

const closed = () => ({ type: NAVIGATION.CLOSED });
const toggled = () => ({ type: NAVIGATION.TOGGLED });

export const navigationActionCreators = {
  closed,
  toggled,
};
