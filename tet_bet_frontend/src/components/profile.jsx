import React, { Component } from "react";
import PlacedBettingTickets from "./Profile/placedBettingTickets";
import Transactions from "./Profile/transactions";

class Profile extends Component {
  state = {
    account: {
      balance: 123.13,
      bettingTickets: [
        {
          id: 23,
          date: "1/11/2022 10:02:35 PM",
          status: "Pending",
          sum: 21,
          totalOdd: 123.14,
          fixtures: [
            {
              homeTeam: {
                name: "Manchester UTD",
                goals: 2,
              },
              awayTeam: {
                name: "Manchester City",
                goals: 2,
              },
              bet: {
                status: "Won",
                name: "Winner",
                odd: {
                  name: "Home",
                  value: 2.0,
                },
              },
            },
            {
              homeTeam: {
                name: "Arsenal",
                goals: 1,
              },
              awayTeam: {
                name: "Chelsea",
                goals: 1,
              },
              bet: {
                status: "Pending",
                name: "Winner",
                odd: {
                  name: "Draw",
                  value: 3.23,
                },
              },
            },
          ],
        },

        {
          id: 23,
          date: "1/11/2022 10:02:35 PM",
          status: "Won",
          sum: 21,
          totalOdd: 123.14,
          fixtures: [
            {
              homeTeam: {
                name: "Manchester UTD",
                goals: 2,
              },
              awayTeam: {
                name: "Manchester City",
                goals: 2,
              },
              bet: {
                status: "Won",
                name: "Winner",
                odd: {
                  name: "Home",
                  value: 2.0,
                },
              },
            },
            {
              homeTeam: {
                name: "Arsenal",
                goals: 1,
              },
              awayTeam: {
                name: "Chelsea",
                goals: 1,
              },
              bet: {
                status: "Pending",
                name: "Winner",
                odd: {
                  name: "Draw",
                  value: 3.23,
                },
              },
            },
          ],
        },
      ],
      transactions: [
        {
          date: "1/11/2022 10:02:35 PM",
          sum: 100,
          currency: "RON",
        },
        {
          date: "1/11/2022 10:02:35 PM",
          sum: -123.2,
          currency: "RON",
        },
        {
          date: "1/11/2022 10:02:35 PM",
          sum: -1000.2,
          currency: "RON",
        },
        {
          date: "1/11/2022 10:02:35 PM",
          sum: 2000.22,
          currency: "EUR",
        },
      ],
    },
  };
  render() {
    return (
      <React.Fragment>
        <div className="container-fluid">
          <div className="row justify-content-left">
            <div class="col-5">
              <PlacedBettingTickets
                bettingTickets={this.state.account.bettingTickets}
              />
            </div>

            <div class="col-5">
              <Transactions account={this.state.account} />
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default Profile;
