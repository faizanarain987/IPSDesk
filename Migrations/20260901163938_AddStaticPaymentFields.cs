using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSDesk.Migrations
{
    /// <inheritdoc />
    public partial class AddStaticPaymentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ComplainCharges",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ConnectionCharges",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FibreCharges",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherCharges",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PackageCharges",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RouterCharges",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplainCharges",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ConnectionCharges",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FibreCharges",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OtherCharges",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PackageCharges",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RouterCharges",
                table: "Payments");
        }
    }
}
