import React, { Component } from "react";
import { ListGroup } from "react-bootstrap";
import FixtureInList from "./fixtureInList";

class FixturesList extends Component {
  render() {
    return (
      <React.Fragment>
        <ListGroup className="mb-2">
          {this.props.fixtures.map((fixture) => (
            <FixtureInList
              fixture={fixture}
              isActive={
                this.props.currentFixtureSelection !== null &&
                fixture.id === this.props.currentFixtureSelection.id
              }
              selectFixture={this.props.selectFixture}
            />
          ))}
        </ListGroup>
      </React.Fragment>
    );
  }
}

export default FixturesList;
