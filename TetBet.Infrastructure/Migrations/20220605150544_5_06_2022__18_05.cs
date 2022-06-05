using Microsoft.EntityFrameworkCore.Migrations;

namespace TetBet.Infrastructure.Migrations
{
    public partial class _5_06_2022__18_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportEntity_Country_CountryId",
                table: "SportEntity");

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                table: "SportEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SportEntity_Country_CountryId",
                table: "SportEntity",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportEntity_Country_CountryId",
                table: "SportEntity");

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                table: "SportEntity",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_SportEntity_Country_CountryId",
                table: "SportEntity",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
