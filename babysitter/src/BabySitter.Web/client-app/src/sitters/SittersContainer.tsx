import * as React from "react";
import { SitterActionCreators } from "./actions";
import { connect } from "react-redux";
import { bindActionCreators, Dispatch } from "redux";
import { IAppState } from "../AppState";
import { getSitters } from "./reducers";
import { SittersList } from "./list";
import { AddSitterDialog } from "./add-sitter/AddSitterDialog";

class Container extends React.Component<any> {
  state = {
    isAdding: false
  };

  componentDidMount() {
    const { loadSitters } = this.props;
    loadSitters();
  }

  render() {
    const { sitters, addSitter } = this.props;
    const { isAdding } = this.state;
    return (
      <div>
        <SittersList sitters={sitters} onAddSitter={this.onAddSitter}/>
        <AddSitterDialog open={isAdding} onSave={s => addSitter(s)} onCancel={this.onCancelAddSitter}/>
      </div>
    );
  }

  private onAddSitter = () => {
    this.setState({ isAdding: true });
  };

  private onCancelAddSitter = () => {
    this.setState({ isAdding: false });
  };
}

const mapStateToProps = (state: IAppState) => {
  return {
    sitters: getSitters(state)
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => ({ ...bindActionCreators(SitterActionCreators, dispatch) });

export const SittersContainer = connect(mapStateToProps, mapDispatchToProps)(Container);