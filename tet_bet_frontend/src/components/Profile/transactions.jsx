import React, { Component } from "react";
import Transactioner from "./transactioner";
import TransactionHistory from "./transactionsHistory";

class Transactions extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <h4>
          <span style={{ float: "right" }}>
            Account balance: {this.props.account.balance}
          </span>
        </h4>
        <br />
        <Transactioner />
        <TransactionHistory transactions={this.props.account.transactions} />
      </React.Fragment>
    );
  }
}

export default Transactions;
