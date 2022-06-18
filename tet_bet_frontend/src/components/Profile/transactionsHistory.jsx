import React, { Component } from "react";
import { ListGroup, ListGroupItem } from "react-bootstrap";

class TransactionHistory extends Component {
  state = {};

  getVariantByTransactionSign = (sum) => (sum > 0 ? "success" : "danger");

  render() {
    return (
      <React.Fragment>
        <h4>Transaction History</h4>
        <ListGroup>
          {this.props.transactions.map((transaction) => (
            <ListGroupItem
              variant={this.getVariantByTransactionSign(transaction.sum)}
            >
              <span style={{ float: "left" }}>{transaction.date}</span>
              <span style={{ float: "right" }}>
                {transaction.sum} {transaction.currency}
              </span>
            </ListGroupItem>
          ))}
        </ListGroup>
        <br />
      </React.Fragment>
    );
  }
}

export default TransactionHistory;
