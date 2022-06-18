import { TextField } from "@material-ui/core";
import React, { Component } from "react";
import TransactionerField from "./transactionerField";

class Transactioner extends Component {
  state = {};

  depositMoney = (value) => {
    // API call
  };

  withdrawMoney = (value) => {
    // API call
  };

  render() {
    return (
      <React.Fragment>
        <TransactionerField
          title="Deposit money"
          onClick={this.props.depositMoney}
        />
        <br />
        <TransactionerField
          title="Withdraw money"
          onClick={this.props.withdrawMoney}
        />
        <br />
        <br />
      </React.Fragment>
    );
  }
}

export default Transactioner;
