import React, { Component } from "react";
import { ListGroupItem } from "react-bootstrap";

class BettingTicketElement extends Component {
  state = {};
  render() {
    return (
      <ListGroupItem>
        {this.props.fixture.dateTime}
        <br />
        <br />
        {this.props.fixture.awayTeam}
        <br />
        {this.props.fixture.homeTeam}
        <br />
        <br />
        {this.props.fixture.bet.name}
        <br />
        {this.props.fixture.bet.oddName} : {this.props.fixture.bet.oddValue}{" "}
        <button
          type="button"
          class="btn btn-danger m-2"
          onClick={() =>
            this.props.onClickDeleteEventFromBettingTicket(
              this.props.fixture.bettingTicketEventId
            )
          }
        >
          X
        </button>
      </ListGroupItem>
    );
  }
}

export default BettingTicketElement;
