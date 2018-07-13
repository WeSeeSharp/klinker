import { Dispatch, bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { IRootState } from '../root.state';
import { navigationActionCreators } from './actions';
import { RootNavigation } from './RootNavigationComponent';
import { getIsOpen } from './reducers/get-is-open.selector';

const mapStateToProps = (state: IRootState) => ({
  isOpen: getIsOpen(state),
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  onClosed: () => dispatch(navigationActionCreators.closed()),
});
export const RootNavigationContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(RootNavigation);
