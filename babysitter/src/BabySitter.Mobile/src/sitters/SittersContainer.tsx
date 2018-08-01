import { connect } from 'react-redux';
import { Action } from 'redux-actions';
import { Dispatch } from 'redux';
import { Sitters } from './SittersComponent';
import { SittersActions } from './actions';
import { RootState } from '../root';
import { getSittersArraySelector } from './reducers';

const mapStateToProps = (state: RootState) => ({
  sitters: getSittersArraySelector(state),
});

const mapDispatchToProps = (dispatch: Dispatch<Action<any>>) => ({
  loadSitters: () => dispatch(SittersActions.loadSitters()),
});

export const SittersContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(Sitters);
