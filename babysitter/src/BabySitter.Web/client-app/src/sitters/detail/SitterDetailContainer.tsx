import { Dispatch } from 'redux';
import { connect } from 'react-redux';
import { IRootState } from '../../root';
import { SitterDetail } from './SitterDetailComponent';
import { withRouter, RouteComponentProps } from 'react-router-dom';
import { getSitterById } from '../reducers/get-sitter-by-id.selector';
import { SitterModel } from '../models';
import { sittersActionCreators } from '../actions';

const mapStateToProps = (state: IRootState, props: RouteComponentProps<any, any>) => ({
  sitter: getSitterById(state, Number(props.match.params.id)),
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  onUpdate: (sitter: SitterModel) => dispatch(sittersActionCreators.save(sitter)),
});

export const SitterDetailContainer = withRouter(
  connect(
    mapStateToProps,
    mapDispatchToProps
  )(SitterDetail)
);
