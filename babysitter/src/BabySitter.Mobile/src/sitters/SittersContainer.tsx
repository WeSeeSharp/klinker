import { connect } from 'react-redux';
import { Sitters } from './SittersComponent';
import { Dispatch } from 'redux';
import { SittersActions } from './actions';
import { Action } from '../common';
import { IRootState } from '../root';
import { getSittersArraySelector } from './reducers';

const mapStateToProps = (state: IRootState) => ({
  sitters: getSittersArraySelector(state),
});

const mapDispatchToProps = (dispatch: Dispatch<Action<any>>) => ({
  loadSitters: () => dispatch(SittersActions.loadSitters()),
});

export const SittersContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(Sitters);
