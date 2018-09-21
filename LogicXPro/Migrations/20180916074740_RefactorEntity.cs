using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicXPro.Migrations
{
    public partial class RefactorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTimeOFArrival",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Orders",
                newName: "StartPreparationTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StartPreparationTime",
                table: "Orders",
                newName: "StartTime");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedTimeOFArrival",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
