import * as React from "react";
import { SitterActionCreators } from "./actions";
import { connect } from "react-redux";
import { bindActionCreators, Dispatch } from "redux";
import { IAppState } from "../common";
import { getSitters } from "./reducers";
import { SittersList } from "./list/SittersList";

class Container extends React.Component<any> {
  componentDidMount() {
    const { loadSitters } = this.props;
    loadSitters();
  }

  render() {
    const { sitters } = this.props;
    return (
      <div>
        <SittersList sitters={sitters} />
      </div>
    );
  }
}

const mapStateToProps = (state: IAppState) => {
  return {
    sitters: getSitters(state)
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => ({ ...bindActionCreators(SitterActionCreators, dispatch) });

export const SittersContainer = connect(mapStateToProps, mapDispatchToProps)(Container);