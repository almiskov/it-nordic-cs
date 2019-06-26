using Microsoft.EntityFrameworkCore.Migrations;

namespace L34_C02_working_with_ef_core_final.Migrations
{
    public partial class UpdateCustomerNameIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UQ_Customers_Name",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name",
                table: "Customers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Name",
                table: "Customers");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_Customers_Name",
                table: "Customers",
                column: "Name");
        }
    }
}
