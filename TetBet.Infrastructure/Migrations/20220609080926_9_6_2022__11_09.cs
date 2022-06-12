using Microsoft.EntityFrameworkCore.Migrations;

namespace TetBet.Infrastructure.Migrations
{
    public partial class _9_6_2022__11_09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SportId",
                table: "GenericBet",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GenericBet_SportId",
                table: "GenericBet",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenericBet_Sport_SportId",
                table: "GenericBet",
                column: "SportId",
                principalTable: "Sport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenericBet_Sport_SportId",
                table: "GenericBet");

            migrationBuilder.DropIndex(
                name: "IX_GenericBet_SportId",
                table: "GenericBet");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "GenericBet");
        }
    }
}
