import React, { Component } from "react";
import { ListGroup } from "react-bootstrap";
import MenuEvent from "./menuEvent";

class MenuEventsList extends Component {
  render() {
    return (
      <ListGroup className="mb-2">
        {this.props.events.map((currentEvent) => (
          <MenuEvent currentEvent={currentEvent} />
        ))}
      </ListGroup>
    );
  }
}

export default MenuEventsList;
