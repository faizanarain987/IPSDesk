using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSDesk.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBillingMonthAndStatusAddDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingMonth",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BillingMonth",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "MonthlyPackageHistories");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "MonthlyPackageHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "MonthlyPackageHistories");

            migrationBuilder.AddColumn<string>(
                name: "BillingMonth",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingMonth",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
