import React, { Component } from "react";
import { ListGroup } from "react-bootstrap";
import FixtureDetailsBets from "./fixtureDetailsBets";

class FixtureDetails extends Component {
  state = {};

  render() {
    return (
      <React.Fragment>
        {this.props.fixture !== null && (
          <ListGroup className="mb-2">
            <span>
              {this.props.fixture.dateTime}
              <br />
              {this.props.fixture.homeTeam} vs {this.props.fixture.awayTeam}
            </span>
            {this.props.fixture.bets.map((currentBet) => (
              <FixtureDetailsBets
                bet={currentBet}
                addBetToBettingTicket={(betName, oddName) =>
                  this.props.addBetToBettingTicket(
                    this.props.fixture,
                    betName,
                    oddName
                  )
                }
              />
            ))}
          </ListGroup>
        )}
      </React.Fragment>
    );
  }
}

export default FixtureDetails;
