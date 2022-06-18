import logo from "./logo.svg";
import "./App.css";
import Menu from "./components/menu";
import Profile from "./components/profile";
import React, { Component } from "react";
import NavigationBar from "./components/navigationBar";

class App extends Component {
  static Menu = 0;
  static Profile = 1;

  state = {
    componentToRenderIndex: App.Menu,
  };

  changeComponentToRender = (componentToRenderIndex) => {
    this.setState({ componentToRenderIndex });
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
