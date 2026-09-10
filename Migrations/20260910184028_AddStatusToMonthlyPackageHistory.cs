using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSDesk.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToMonthlyPackageHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MonthlyPackageHistories");
        }
    }
}
