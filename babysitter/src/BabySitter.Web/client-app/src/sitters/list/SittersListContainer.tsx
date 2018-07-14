import { Dispatch } from 'redux';
import { connect } from 'react-redux';
import { SittersList } from './SittersListComponent';
import { IRootState } from '../../root';
import { getSittersList } from '../reducers/get-sitters-list.selector';
import { sittersActionCreators } from '../actions';

const mapStateToProps = (state: IRootState) => ({
  sitters: getSittersList(state),
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  onLoad: () => dispatch(sittersActionCreators.load()),
});

export const SittersListContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(SittersList);
