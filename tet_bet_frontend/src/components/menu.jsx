import React, { Component } from "react";
import FixturesList from "./fixturesList";
import Filters from "./filters";
import BettingTicket from "./BettingTicket/bettingTicket";
import FixtureDetails from "./fixtureDetails";
import ReactJsAlert from "reactjs-alert";

class Menu extends Component {
  state = {
    alertMultipleBetsOfSameFixtureState: false,
    currentFilteredCountry: {
      id: 0,
      name: "All Countries",
    },
    currentFilteredCompetition: {},
    currentFixtureSelection: null,

    bettingTicket: {
      eventsIndex: 0,
      totalOdd: 1.0,
      sum: 0,
      fixtures: [],
    },

    events: [
      {
        countryId: 1,
        countryName: "England",
        competitions: [
          {
            id: 1,
            name: "Premier League",
            fixtures: [
              {
                id: 123,
                homeTeam: "Manchester UTD",
                awayTeam: "Manchester City",
                dateTime: "30-05-2022, 21:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                  {
                    name: "Exact Score",
                    odds: [
                      {
                        name: "0:0",
                        value: 2.4,
                      },
                      {
                        name: "1:0",
                        value: 2.4,
                      },
                      {
                        name: "0:1",
                        value: 2.4,
                      },
                      {
                        name: "1:1",
                        value: 2.4,
                      },
                      {
                        name: "2:0",
                        value: 2.4,
                      },
                      {
                        name: "0:2",
                        value: 2.4,
                      },
                      {
                        name: "1:2",
                        value: 2.4,
                      },
                      {
                        name: "2:1",
                        value: 2.4,
                      },
                      {
                        name: "2:2",
                        value: 2.4,
                      },
                    ],
                  },
                ],
              },
              {
                id: 321,
                homeTeam: "Everton",
                awayTeam: "Fulham",
                dateTime: "30-05-2022, 20:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                ],
              },
            ],
          },
          {
            id: 5134,
            name: "Championship",
            fixtures: [
              {
                id: 123,
                homeTeam: "Crew Alexandria",
                awayTeam: "Derby Country",
                dateTime: "30-05-2022, 21:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                  {
                    name: "Exact Score",
                    odds: [
                      {
                        name: "0:0",
                        value: 2.4,
                      },
                      {
                        name: "1:0",
                        value: 2.4,
                      },
                      {
                        name: "0:1",
                        value: 2.4,
                      },
                      {
                        name: "1:1",
                        value: 2.4,
                      },
                      {
                        name: "2:0",
                        value: 2.4,
                      },
                      {
                        name: "0:2",
                        value: 2.4,
                      },
                      {
                        name: "1:2",
                        value: 2.4,
                      },
                      {
                        name: "2:1",
                        value: 2.4,
                      },
                      {
                        name: "2:2",
                        value: 2.4,
                      },
                    ],
                  },
                ],
              },
              {
                id: 321,
                homeTeam: "Cardiff",
                awayTeam: "Stoke",
                dateTime: "30-05-2022, 20:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                ],
              },
            ],
          },
        ],
      },
      {
        countryId: 2,
        countryName: "France",
        competitions: [
          {
            id: 100,
            name: "Ligue 1",
            fixtures: [
              {
                id: 111,
                homeTeam: "PSG",
                awayTeam: "Olympique Marseille",
                dateTime: "30-05-2022, 21:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                  {
                    name: "Exact Score",
                    odds: [
                      {
                        name: "0:0",
                        value: 2.4,
                      },
                      {
                        name: "1:0",
                        value: 2.4,
                      },
                      {
                        name: "0:1",
                        value: 2.4,
                      },
                      {
                        name: "1:1",
                        value: 2.4,
                      },
                      {
                        name: "2:0",
                        value: 2.4,
                      },
                      {
                        name: "0:2",
                        value: 2.4,
                      },
                      {
                        name: "1:2",
                        value: 2.4,
                      },
                      {
                        name: "2:1",
                        value: 2.4,
                      },
                      {
                        name: "2:2",
                        value: 2.4,
                      },
                    ],
                  },
                ],
              },
              {
                id: 500,
                homeTeam: "Lille",
                awayTeam: "Bordeaux",
                dateTime: "30-05-2022, 20:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                ],
              },
            ],
          },
          {
            id: 600,
            name: "Ligue 2",
            fixtures: [
              {
                id: 6531,
                homeTeam: "Lens",
                awayTeam: "CS Metz",
                dateTime: "30-05-2022, 21:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                  {
                    name: "Exact Score",
                    odds: [
                      {
                        name: "0:0",
                        value: 2.4,
                      },
                      {
                        name: "1:0",
                        value: 2.4,
                      },
                      {
                        name: "0:1",
                        value: 2.4,
                      },
                      {
                        name: "1:1",
                        value: 2.4,
                      },
                      {
                        name: "2:0",
                        value: 2.4,
                      },
                      {
                        name: "0:2",
                        value: 2.4,
                      },
                      {
                        name: "1:2",
                        value: 2.4,
                      },
                      {
                        name: "2:1",
                        value: 2.4,
                      },
                      {
                        name: "2:2",
                        value: 2.4,
                      },
                    ],
                  },
                ],
              },
              {
                id: 64301,
                homeTeam: "Le Havre",
                awayTeam: "Rouen",
                dateTime: "30-05-2022, 20:45",
                bets: [
                  {
                    name: "Match Winner",
                    odds: [
                      {
                        name: "Home",
                        value: 2.4,
                      },
                      {
                        name: "Draw",
                        value: 3.0,
                      },
                      {
                        name: "Away",
                        value: 2.6,
                      },
                    ],
                  },
                ],
              },
            ],
          },
        ],
      },
    ],
  };

  selectFixture = (fixtureId) => {
    this.setState({ currentFixtureSelection: fixtureId });
  };

  bettingTicketSumChanged = (value) => {
    const bettingTicket = this.state.bettingTicket;
    bettingTicket.sum = value;
    this.setState({ bettingTicket });
  };

  addBetToBettingTicket = (fixture, betName, oddName) => {
    if (
      this.state.bettingTicket.fixtures.filter(
        (bettingTicketFixture) => bettingTicketFixture.fixtureId === fixture.id
      ).length !== 0
    ) {
      this.setState({ alertMultipleBetsOfSameFixtureState: true });
      return;
    }

    const bet = fixture.bets.find((bet) => bet.name === betName);
    const odd = bet.odds.find((odd) => odd.name === oddName);

    const bettingTicket = this.state.bettingTicket;
    bettingTicket.eventsIndex += 1;

    bettingTicket.fixtures.push({
      bettingTicketEventId: bettingTicket.eventsIndex,
      fixtureId: fixture.id,
      homeTeam: fixture.homeTeam,
      awayTeam: fixture.awayTeam,
      dateTime: fixture.dateTime,
      bet: {
        name: bet.name,
        oddName: odd.name,
        oddValue: odd.value,
      },
    });

    bettingTicket.totalOdd *= odd.value;

    this.setState({ bettingTicket });
  };

  deleteEventFromBettingTicket = (bettingTicketEventId) => {
    let bettingTicket = this.state.bettingTicket;

    const bettingTicketEventToDelete = this.state.bettingTicket.fixtures.filter(
      (event) => event.bettingTicketEventId === bettingTicketEventId
    )[0];

    const bettingTicketUpdatedEvents = this.state.bettingTicket.fixtures.filter(
      (event) => event.bettingTicketEventId !== bettingTicketEventId
    );

    bettingTicket.totalOdd /= bettingTicketEventToDelete.bet.oddValue;
    bettingTicket.fixtures = bettingTicketUpdatedEvents;

    this.setState({ bettingTicket });
  };

  getCountries = () => {
    const countries = [];
    countries.push({
      id: 0,
      name: "All Countries",
    });
    this.state.events.map((event) =>
      countries.push({
        id: event.countryId,
        name: event.countryName,
      })
    );
    return countries;
  };

  filterCountries = (selectedCountry) => {
    if (selectedCountry.id !== this.state.currentFilteredCountry.id) {
      const competitionsOfSelectedCountry =
        this.getCompetitionsOfCountry(selectedCountry);

      this.setState({
        currentFilteredCompetition: competitionsOfSelectedCountry[0],
      });
    }

    this.setState({ currentFilteredCountry: selectedCountry });
  };

  filterCompetitions = (selectedCompetition) => {
    this.setState({ currentFilteredCompetition: selectedCompetition });
  };

  getFilteredFixtures = () => {
    const competitionsOfFilteredCountry = this.getCompetitionsOfCountry(
      this.state.currentFilteredCountry
    );

    if (Object.keys(this.state.currentFilteredCompetition).length === 0)
      return competitionsOfFilteredCountry[0].fixtures;

    const filteredCompetition = competitionsOfFilteredCountry.find(
      (competition) =>
        competition.id === this.state.currentFilteredCompetition.id
    );

    return filteredCompetition.fixtures;
  };

  getCompetitionsOfCountry = (country) => {
    let competitions = [];

    if (country !== null)
      if (country.id === 0)
        this.state.events.map((event) =>
          event.competitions.map((competition) =>
            competitions.push(competition)
          )
        );
      else
        this.state.events
          .find((event) => event.countryId === country.id)
          .competitions.map((competition) => competitions.push(competition));

    return competitions;
  };

  getCompetitionsIdAndNameOfFilteredCountry = () => {
    let competitions = [];

    if (this.state.currentFilteredCountry !== null)
      if (this.state.currentFilteredCountry.id === 0)
        this.state.events.map((event) =>
          event.competitions.map((competition) =>
            competitions.push({
              id: competition.id,
              name: competition.name,
            })
          )
        );
      else
        this.state.events
          .filter(
            (event) => event.countryId === this.state.currentFilteredCountry.id
          )[0]
          .competitions.map((competition) =>
            competitions.push({
              id: competition.id,
              name: competition.name,
            })
          );
    return competitions;
  };

  render() {
    return (
      <React.Fragment>
        <ReactJsAlert
          status={this.state.alertMultipleBetsOfSameFixtureState}
          type="alert"
          title="You cannot place multiple bets on the same event"
          Close={() =>
            this.setState({ alertMultipleBetsOfSameFixtureState: false })
          }
        />

        <div className="d-flex justify-content-start">
          <Filters
            className="p-2 col-example text-left"
            elements={this.getCountries()}
            onSelection={this.filterCountries}
          />
          <Filters
            className="p-2 col-example text-left"
            elements={this.getCompetitionsIdAndNameOfFilteredCountry()}
            onSelection={this.filterCompetitions}
          />
        </div>
        <div class="d-flex justify-content-between">
          <FixturesList
            currentFixtureSelection={this.state.currentFixtureSelection}
            fixtures={this.getFilteredFixtures()}
            selectFixture={this.selectFixture}
            className="p-2 col-example text-left"
          />

          <FixtureDetails
            addBetToBettingTicket={(fixture, betName, oddName) =>
              this.addBetToBettingTicket(fixture, betName, oddName)
            }
            fixture={this.state.currentFixtureSelection}
            className="p-2 col-example text-left"
          />

          <BettingTicket
            bettingTicket={this.state.bettingTicket}
            className="p-2 col-example text-left"
            deleteEventFromBettingTicket={this.deleteEventFromBettingTicket}
            handleBettingTicketSumTextFieldChange={this.bettingTicketSumChanged}
          />
        </div>
      </React.Fragment>
    );
  }
}

export default Menu;
