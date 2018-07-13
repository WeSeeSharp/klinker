import { IRootState } from '../root.state';
import { Dispatch } from 'redux';
import { connect } from 'react-redux';
import { navigationActionCreators } from '../navigation/actions';
import { RootAppBar } from './RootAppBarComponent';

const mapStateToProps = (state: IRootState) => ({});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  onMenuToggled: () => dispatch(navigationActionCreators.toggled()),
});

export const RootAppBarContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(RootAppBar);
