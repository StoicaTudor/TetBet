import React, { Component } from "react";
import { ListGroupItem } from "react-bootstrap";

class FixtureDetailsBets extends Component {
  state = {};

  render() {
    return (
      <ListGroupItem>
        {this.props.bet.name}
        <br />
        {this.props.bet.odds.map((currentOdd) => (
          <button
            onClick={() =>
              this.props.addBetToBettingTicket(
                this.props.bet.name,
                currentOdd.name
              )
            }
            className="btn btn-primary m-2"
          >
            {currentOdd.name} {currentOdd.value}
          </button>
        ))}
      </ListGroupItem>
    );
  }
}

export default FixtureDetailsBets;
