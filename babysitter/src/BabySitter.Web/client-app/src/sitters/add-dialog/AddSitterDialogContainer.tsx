import { Dispatch } from 'redux';
import { connect } from 'react-redux';
import { AddSitterDialog } from './AddSitterDialogComponent';
import { IRootState } from '../../root';
import { getIsAdding } from '../reducers/get-is-adding.selector';
import { sittersActionCreators } from '../actions';
import { AddSitterModel } from '../models';

const mapStateToProps = (state: IRootState) => ({
  isOpen: getIsAdding(state) || false,
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  onCancelled: () => dispatch(sittersActionCreators.addCancelled()),
  onSaved: (sitter: AddSitterModel) => dispatch(sittersActionCreators.add(sitter)),
});

export const AddSitterDialogContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(AddSitterDialog);
