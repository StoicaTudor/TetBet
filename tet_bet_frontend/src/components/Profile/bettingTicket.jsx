import React, { Component } from "react";
import { ListGroup, ListGroupItem } from "react-bootstrap";
import BettingTicketBet from "./bettingTicketBet";

class BettingTicket extends Component {
  bettingTicketStatusToListGroupClass = (status) => {
    let divClassName = null;

    switch (status) {
      case "Lost":
        divClassName = "list-group-item-danger";
        break;

      case "Won":
        divClassName = "list-group-item-success";
        break;

      case "Pending":
        divClassName = "list-group-item-warning";
        break;
    }

    return divClassName;
  };

  render() {
    return (
      <React.Fragment>
        <div
          className={this.bettingTicketStatusToListGroupClass(
            this.props.bettingTicket.status
          )}
        >
          <span>
            <b>Id: {this.props.bettingTicket.id}</b>
            <span style={{ float: "right" }}>
              {this.props.bettingTicket.date}
            </span>
          </span>

          <ListGroup>
            {this.props.bettingTicket.fixtures.map((fixture) => (
              <BettingTicketBet fixture={fixture} />
            ))}
            <ListGroupItem>
              <span>
                Sum: <b>{this.props.bettingTicket.sum.toFixed(2)}</b>
              </span>
              <span style={{ float: "right" }}>
                Profit: <b>{this.props.bettingTicket.totalOdd.toFixed(2)}</b>
              </span>
            </ListGroupItem>
          </ListGroup>
        </div>
        <br />
      </React.Fragment>
    );
  }
}

export default BettingTicket;
