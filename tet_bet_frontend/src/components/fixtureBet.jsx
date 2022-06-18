import React, { Component } from "react";

class FixtureBet extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <div class="col">
          {this.props.eventBets.odds.map((odd) => (
            <button type="button" class="btn btn-info m-2">
              {odd.name} {odd.value}
            </button>
          ))}
        </div>
      </React.Fragment>
    );
  }
}

export default FixtureBet;
