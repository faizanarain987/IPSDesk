using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSDesk.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AddedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_CollectedById",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CollectedById",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CollectedById",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PaymentMethods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PaymentMethods",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Packages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MonthlyPackageHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MonthlyPackageHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MonthlyPackageHistories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "MonthlyPackageHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedByName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "UpdatedByName",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UpdatedByName",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "UpdatedByName",
                table: "MonthlyPackageHistories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedByName",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "CollectedById",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CollectedById",
                table: "Payments",
                column: "CollectedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddedById",
                table: "Customers",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AddedById",
                table: "Customers",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_CollectedById",
                table: "Payments",
                column: "CollectedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
