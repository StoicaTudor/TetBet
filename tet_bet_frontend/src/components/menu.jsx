import React, { Component } from "react";
import MenuEventsList from "./menuEventsList";

class Menu extends Component {
  state = {
    events: [
      {
        homeTeam: "Manchester UTD",
        awayTeam: "Manchester City",
        dateTime: "30-05-2022, 21:45",
      },
      {
        homeTeam: "Everton",
        awayTeam: "Fulham",
        dateTime: "30-05-2022, 20:45",
      },
    ],
  };
  render() {
    return (
      <React.Fragment>
        <MenuEventsList events={this.state.events} />
      </React.Fragment>
    );
  }
}

export default Menu;
