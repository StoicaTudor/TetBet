import "./App.css";
import Menu from "./components/menu";
import Profile from "./components/profile";
import React, { Component } from "react";
import NavigationBar from "./components/navigationBar";
import Login from "./components/Login/login";

class App extends Component {
  static UserId = 0;

  static Menu = 0;
  static Profile = 1;
  static Login = 2;
  static AppStart = 3;

  state = {
    componentToRenderIndex: App.AppStart,
  };

  changeComponentToRender = (componentToRenderIndex) => {
    this.setState({ componentToRenderIndex });
  };

  getSessionUserId = () => {
    let valueToReturn = 0;

    let requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
    };
    fetch(
      "https://localhost:5001/TetBet/Login/getSessionUserId",
      requestOptions
    )
      .then((response) => {
        console.log(response.status);

        if (response.status === 204) valueToReturn = 0;
      })
      .then((value) => {
        if (!NaN(value)) valueToReturn = value;
      });

    return valueToReturn;
  };

  render() {
    let componentToRender = null;

    switch (this.state.componentToRenderIndex) {
      case App.Menu:
        componentToRender = (
          <Menu renderComponent={this.changeComponentToRender} />
        );
        break;
      case App.Profile:
        componentToRender = (
          <Profile renderComponent={this.changeComponentToRender} />
        );
        break;
      case App.Login:
        componentToRender = (
          <Login renderComponent={this.changeComponentToRender} />
        );
        break;
      case App.AppStart:
        let sessionUserId = this.getSessionUserId();

        if (sessionUserId === 0)
          componentToRender = (
            <Login renderComponent={this.changeComponentToRender} />
          );
        else
          componentToRender = (
            <Menu renderComponent={this.changeComponentToRender} />
          );
        break;
    }

    return (
      <React.Fragment>
        <NavigationBar renderComponent={this.changeComponentToRender} />
        {componentToRender}
      </React.Fragment>
    );
  }
}

export default App;
