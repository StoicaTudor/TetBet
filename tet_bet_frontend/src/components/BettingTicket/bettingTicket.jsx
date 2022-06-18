import React, { Component } from "react";
import BettingTicketElement from "./bettingTicketElement";
import { ListGroup } from "react-bootstrap";
import TextField from "@material-ui/core/TextField";

class BettingTicket extends Component {
  state = {
    bettingTicketSumTextFieldValue: "",
  };

  handleBettingTicketSumTextfieldChange = (value) => {
    if (isNaN(value)) return;
    this.setState({ bettingTicketSumTextFieldValue: value });
    this.props.handleBettingTicketSumTextFieldChange(value);
  };

  render() {
    return (
      <React.Fragment>
        <div>
          <ListGroup className="mb-2 p-2 text-left">
            {this.props.bettingTicket.fixtures.map((fixture) => (
              <BettingTicketElement
                fixture={fixture}
                onClickDeleteEventFromBettingTicket={
                  this.props.deleteEventFromBettingTicket
                }
              />
            ))}
          </ListGroup>
          Potential Win:{" "}
          {this.props.bettingTicket.totalOdd * this.props.bettingTicket.sum}
          <br />
          <TextField
            type="text"
            placeholder="Betting Ticket Sum"
            onChange={(event) => {
              this.handleBettingTicketSumTextfieldChange(event.target.value);
            }}
            value={this.state.bettingTicketSumTextFieldValue}
          />
          <button type="button" class="btn btn-success m-2">
            Place Betting Ticket
          </button>
        </div>
      </React.Fragment>
    );
  }
}

export default BettingTicket;
