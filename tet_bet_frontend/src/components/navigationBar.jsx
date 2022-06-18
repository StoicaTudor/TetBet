import React, { Component } from "react";
import { Container, Nav, Navbar } from "react-bootstrap";
import App from "../App";

class NavigationBar extends Component {
  state = {};

  goToProfile = () => {
    this.props.renderComponent(App.Profile);
  };

  goToMenu = () => {
    this.props.renderComponent(App.Menu);
  };

  render() {
    return (
      <Navbar bg="primary" variant="dark">
        <Container>
          <Navbar.Brand>Tet Bet</Navbar.Brand>

          <Nav className="me-auto">
            <Nav.Link
              onClick={() => {
                this.goToMenu();
              }}
            >
              Menu
            </Nav.Link>

            <Nav.Link
              onClick={() => {
                this.goToProfile();
              }}
            >
              Profile
            </Nav.Link>

            <Nav.Link>Sign Out</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
    );
  }
}

export default NavigationBar;
