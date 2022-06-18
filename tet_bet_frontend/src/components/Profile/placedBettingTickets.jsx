import React, { Component } from "react";
import { ListGroup } from "react-bootstrap";
import BettingTicket from "./bettingTicket";

class PlacedBettingTickets extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <h4>Placed Bets</h4>
        <ListGroup>
          {this.props.bettingTickets.map((bettingTicket) => (
            <BettingTicket bettingTicket={bettingTicket} />
          ))}
        </ListGroup>
      </React.Fragment>
    );
  }
}

export default PlacedBettingTickets;
