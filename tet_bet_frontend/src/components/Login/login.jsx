import { TextField } from "@material-ui/core";
import React, { Component } from "react";
import PasswordMask from "react-password-mask";
import App from "../../App";

class Login extends Component {
  state = {};

  goToMenu = () => {
    this.props.renderComponent(App.Menu);
  };

  login = (email, password, loginType) => {
    let requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        email: email,
        password: password,
      }),
    };

    fetch("https://localhost:5001/TetBet/Login/" + loginType, requestOptions)
      .then((response) => {
        response.json();
      })
      .then((value) => {
        App.UserId = value;
      });

    this.goToMenu();
  };

  render() {
    return (
      <React.Fragment>
        <h5> Login</h5>
        <div>
          <div>
            <TextField type="text" placeholder="Email" />
            <br />
            <PasswordMask
              type="text"
              placeholder="Password"
              useVendorStyles={false}
            />
            <br />

            <button
              type="button"
              className="btn btn-block btn-primary"
              style={{ float: "center" }}
              onClick={() => {
                this.login("tudor", "123", "signIn");
              }}
            >
              Sign In
            </button>

            <button
              type="button"
              className="btn btn-block btn-primary"
              style={{ float: "center" }}
              onClick={() => {
                this.login("tudor", "123", "signUp");
              }}
            >
              Sign Up
            </button>
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default Login;
