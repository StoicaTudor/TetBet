import { TextField } from "@material-ui/core";
import React, { Component } from "react";

class TransactionerField extends Component {
  state = {
    textFieldValue: "",
  };

  handleTextFieldChange = (value) => {
    if (isNaN(value)) return;
    this.setState({ textFieldValue: value });
  };

  render() {
    return (
      <React.Fragment>
        <h5> {this.props.title}</h5>
        <div className="row">
          <div className="col">
            <TextField
              type="text"
              placeholder="Sum"
              onChange={(event) => {
                this.handleTextFieldChange(event.target.value);
              }}
              value={this.state.textFieldValue}
            />
            <button
              type="button"
              className="btn btn-block btn-primary"
              style={{ float: "center" }}
              onClick={() => {
                this.props.onClick(this.state.textFieldValue);
              }}
            >
              Confirm
            </button>
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default TransactionerField;
