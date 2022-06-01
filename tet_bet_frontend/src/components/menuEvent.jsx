import React, { Component } from "react";
import { ListGroupItem } from "react-bootstrap";

class MenuEvent extends Component {
  state = {};

  alertClicked() {
    console.log("clicked");
  }

  render() {
    return (
      <ListGroupItem onClick={this.alertClicked} aria-current='true'>
        <span>
          {this.props.currentEvent.homeTeam} vs{" "}
          {this.props.currentEvent.awayTeam}
        </span>
        <span>{this.props.currentEvent.dateTime}</span>
      </ListGroupItem>
    );
  }
}

export default MenuEvent;
