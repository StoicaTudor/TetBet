import React, { Component } from "react";
import { ListGroupItem } from "react-bootstrap";

class BettingTicketBet extends Component {
  state = {};

  betStatusToVariant = (status) => {
    let variant = null;

    switch (status) {
      case "Won":
        variant = "success";
        break;

      case "Lost":
        variant = "danger";
        break;

      case "Pending":
        variant = "warning";
        break;
    }

    return variant;
  };

  render() {
    return (
      <ListGroupItem
        variant={this.betStatusToVariant(this.props.fixture.bet.status)}
      >
        <div>
          <b>{this.props.fixture.bet.odd.name}</b>
          <span style={{ float: "right" }}>
            <b>{this.props.fixture.bet.odd.value.toFixed(2)}</b>
          </span>
        </div>
        {this.props.fixture.bet.name}
        <br />
        {this.props.fixture.homeTeam.name} - {this.props.fixture.awayTeam.name}
        <br />
        {this.props.fixture.homeTeam.goals} -{" "}
        {this.props.fixture.awayTeam.goals}
      </ListGroupItem>
    );
  }
}

export default BettingTicketBet;
