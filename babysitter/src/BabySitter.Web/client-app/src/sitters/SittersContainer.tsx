import * as React from "react";
import { SitterActionCreators } from "./actions";
import { connect } from "react-redux";
import { bindActionCreators, Dispatch } from "redux";
import { IAppState } from "../AppState";
import { getSitters } from "./reducers";
import { SittersList } from "./list";
import { AddSitterDialog } from "./add-sitter";
import { Theme, withStyles } from "@material-ui/core";
import { StyleRules } from "@material-ui/core/styles";

class Container extends React.Component<any> {
  state = {
    isAdding: false
  };

  componentDidMount() {
    const { loadSitters } = this.props;
    loadSitters();
  }

  render() {
    const { sitters, addSitter, classes } = this.props;
    const { isAdding } = this.state;
    return (
      <div className={classes.main}>
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

const styles = (theme: Theme): StyleRules<string> => ({
  main: {
    flexGrow: 1,
    display: "flex",
    flex: 1,
    height: "100%"
  }
});

const StyledContainer = withStyles(styles)(Container);

const mapStateToProps = (state: IAppState) => {
  return {
    sitters: getSitters(state)
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => ({ ...bindActionCreators(SitterActionCreators, dispatch) });

export const SittersContainer = connect(mapStateToProps, mapDispatchToProps)(StyledContainer);