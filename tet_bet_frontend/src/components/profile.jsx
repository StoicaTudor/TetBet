import React, { Component } from "react";
import PlacedBettingTickets from "./Profile/placedBettingTickets";
import Transactions from "./Profile/transactions";

class Profile extends Component {
  state = {
    account: {
      id: 2,
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
                status: "Won",
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
          status: "Lost",
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
                status: "Pending",
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
                status: "Lost",
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

  depositMoney = (value) => {
    // this.transactionMoney(value, "depositMoney");
    const account = this.state.account;
    account.balance = this.state.account.balance + parseFloat(value);
    this.setState({ account: account });
  };

  withdrawMoney = (value) => {
    // this.transactionMoney(value, "withdrawMoney");
    const account = this.state.account;
    account.balance = this.state.account.balance - parseFloat(value);
    this.setState({ account: account });
  };

  transactionMoney = (value, transactionType) => {
    let requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        value: value,
        accountId: this.state.account.id,
      }),
    };

    fetch(
      "https://localhost:5001/TetBet/AccountDetails/" + transactionType,
      requestOptions
    )
      .then((response) => {
        response.json();
      })
      .then((responseValue) => {
        const transactions = this.state.account.transactions;
        transactions.push(responseValue);
        this.setState({ transactions });
      });
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
              <Transactions
                account={this.state.account}
                depositMoney={this.depositMoney}
                withdrawMoney={this.withdrawMoney}
              />
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default Profile;
