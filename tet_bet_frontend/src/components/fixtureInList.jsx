import React, { Component } from "react";
import { ListGroupItem } from "react-bootstrap";

class FixtureInList extends Component {
  state = {};

  getListGroupItem = () => {
    let listGroupItem = (
      <ListGroupItem
        onClick={() => {
          this.props.selectFixture(this.props.fixture);
        }}
        aria-current="true"
      >
        <span>
          {this.props.fixture.dateTime}
          <br />
          {this.props.fixture.homeTeam}
          <br />
          {this.props.fixture.awayTeam}
        </span>
      </ListGroupItem>
    );

    if (this.props.isActive)
      listGroupItem = (
        <ListGroupItem aria-current="true" active>
          <span>
            {this.props.fixture.dateTime}
            <br />
            {this.props.fixture.homeTeam}
            <br />
            {this.props.fixture.awayTeam}
          </span>
        </ListGroupItem>
      );

    return listGroupItem;
  };

  render() {
    return this.getListGroupItem();
  }
}

export default FixtureInList;
