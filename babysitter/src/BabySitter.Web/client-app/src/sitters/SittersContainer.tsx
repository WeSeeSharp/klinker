import * as React from "react";
import { SitterActionCreators } from "./actions";
import { connect } from "react-redux";
import { bindActionCreators, Dispatch } from "redux";
import { IAppState } from "../AppState";
import { getIsAddingSitter, getSitters } from "./reducers";
import { SittersList } from "./list";
import { AddSitterDialog } from "./add-sitter";
import { Theme, withStyles } from "@material-ui/core";
import { StyleRules } from "@material-ui/core/styles";

class Container extends React.Component<any> {
  componentDidMount() {
    const { loadSitters } = this.props;
    loadSitters();
  }

  render() {
    const { sitters, addSitter, addSitterBegin, addSitterCancel, isAdding, classes, children } = this.props;
    return (
      <div className={classes.main}>
        <SittersList sitters={sitters} onAddSitter={addSitterBegin}/>
        {children}
        <AddSitterDialog open={isAdding} onSave={s => addSitter(s)} onCancel={addSitterCancel}/>
      </div>
    );
  }
}

const styles = (theme: Theme): StyleRules<string> => ({
  main: {
    flexGrow: 1,
    display: "flex",
    flex: 1
  }
});

const StyledContainer = withStyles(styles)(Container);

const mapStateToProps = (state: IAppState) => {
  return {
    sitters: getSitters(state),
    isAdding: getIsAddingSitter(state)
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => ({ ...bindActionCreators(SitterActionCreators, dispatch) });

export const SittersContainer = connect(mapStateToProps, mapDispatchToProps)(StyledContainer);