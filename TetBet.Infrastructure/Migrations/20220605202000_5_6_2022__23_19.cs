using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TetBet.Infrastructure.Migrations
{
    public partial class _5_6_2022__23_19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateRegistered = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountBalance = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RapidApiConfigData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapidApiConfigData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RapidApiKey",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    ApiDescription = table.Column<string>(type: "text", nullable: true),
                    RemainingCalls = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapidApiKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BettingTicket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Sum = table.Column<float>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    BettingTicketStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BettingTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BettingTicket_AccountDetails_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AccountDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Sum = table.Column<float>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountDetailsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AccountDetails_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AccountDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    AccountDetailsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AccountDetails_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AccountDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    HomeStadium = table.Column<string>(type: "text", nullable: true),
                    RapidApiId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportEntity_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SportId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    RapidApiId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericBet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SportId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericBet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericBet_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportRelatedHuman",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NationalityId = table.Column<long>(type: "bigint", nullable: true),
                    SportRelatedHumanType = table.Column<int>(type: "int", nullable: false),
                    RapidApiId = table.Column<long>(type: "bigint", nullable: false),
                    SportEntityId = table.Column<long>(type: "bigint", nullable: true),
                    SportEntityId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportRelatedHuman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportRelatedHuman_Country_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SportRelatedHuman_SportEntity_SportEntityId",
                        column: x => x.SportEntityId,
                        principalTable: "SportEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SportRelatedHuman_SportEntity_SportEntityId1",
                        column: x => x.SportEntityId1,
                        principalTable: "SportEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionSportEntity",
                columns: table => new
                {
                    CompetitionsId = table.Column<long>(type: "bigint", nullable: false),
                    SportEntitiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionSportEntity", x => new { x.CompetitionsId, x.SportEntitiesId });
                    table.ForeignKey(
                        name: "FK_CompetitionSportEntity_Competition_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionSportEntity_SportEntity_SportEntitiesId",
                        column: x => x.SportEntitiesId,
                        principalTable: "SportEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportEvent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompetitionId = table.Column<long>(type: "bigint", nullable: true),
                    SportEventStatus = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    SportEventDetails = table.Column<string>(type: "text", nullable: true),
                    RapidApiId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportEvent_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BetName = table.Column<string>(type: "text", nullable: true),
                    RapidApiId = table.Column<long>(type: "bigint", nullable: false),
                    GenericBetId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bet_GenericBet_GenericBetId",
                        column: x => x.GenericBetId,
                        principalTable: "GenericBet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportEventBet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BetId = table.Column<long>(type: "bigint", nullable: true),
                    SportEventId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEventBet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportEventBet_Bet_BetId",
                        column: x => x.BetId,
                        principalTable: "Bet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SportEventBet_SportEvent_SportEventId",
                        column: x => x.SportEventId,
                        principalTable: "SportEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<float>(type: "float", nullable: false),
                    BetId = table.Column<long>(type: "bigint", nullable: true),
                    SportEventBetId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odd_Bet_BetId",
                        column: x => x.BetId,
                        principalTable: "Bet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Odd_SportEventBet_SportEventBetId",
                        column: x => x.SportEventBetId,
                        principalTable: "SportEventBet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SportEventBetId = table.Column<long>(type: "bigint", nullable: true),
                    UserBetStatus = table.Column<int>(type: "int", nullable: false),
                    BettingTicketId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBet_BettingTicket_BettingTicketId",
                        column: x => x.BettingTicketId,
                        principalTable: "BettingTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBet_SportEventBet_SportEventBetId",
                        column: x => x.SportEventBetId,
                        principalTable: "SportEventBet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GenericBetId",
                table: "Bet",
                column: "GenericBetId");

            migrationBuilder.CreateIndex(
                name: "IX_BettingTicket_AccountDetailsId",
                table: "BettingTicket",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_CountryId",
                table: "Competition",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_SportId",
                table: "Competition",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionSportEntity_SportEntitiesId",
                table: "CompetitionSportEntity",
                column: "SportEntitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericBet_SportId",
                table: "GenericBet",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Odd_BetId",
                table: "Odd",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_Odd_SportEventBetId",
                table: "Odd",
                column: "SportEventBetId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEntity_CountryId",
                table: "SportEntity",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEvent_CompetitionId",
                table: "SportEvent",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEventBet_BetId",
                table: "SportEventBet",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEventBet_SportEventId",
                table: "SportEventBet",
                column: "SportEventId");

            migrationBuilder.CreateIndex(
                name: "IX_SportRelatedHuman_NationalityId",
                table: "SportRelatedHuman",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SportRelatedHuman_SportEntityId",
                table: "SportRelatedHuman",
                column: "SportEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SportRelatedHuman_SportEntityId1",
                table: "SportRelatedHuman",
                column: "SportEntityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountDetailsId",
                table: "Transaction",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountDetailsId",
                table: "User",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBet_BettingTicketId",
                table: "UserBet",
                column: "BettingTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBet_SportEventBetId",
                table: "UserBet",
                column: "SportEventBetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionSportEntity");

            migrationBuilder.DropTable(
                name: "Odd");

            migrationBuilder.DropTable(
                name: "RapidApiConfigData");

            migrationBuilder.DropTable(
                name: "RapidApiKey");

            migrationBuilder.DropTable(
                name: "SportRelatedHuman");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserBet");

            migrationBuilder.DropTable(
                name: "SportEntity");

            migrationBuilder.DropTable(
                name: "BettingTicket");

            migrationBuilder.DropTable(
                name: "SportEventBet");

            migrationBuilder.DropTable(
                name: "AccountDetails");

            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "SportEvent");

            migrationBuilder.DropTable(
                name: "GenericBet");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Sport");
        }
    }
}
