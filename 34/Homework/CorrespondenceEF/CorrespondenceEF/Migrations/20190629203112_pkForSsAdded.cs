using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorrespondenceEF.Migrations
{
    public partial class pkForSsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_Positions_PositionId",
                table: "Contractors");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_PostalItems_PostalItemId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Addresses_RecievingAddressId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Contractors_RecievingContractorId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Addresses_SendingAddressId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Contractors_SendingContractorId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Statuses_StatusId",
                table: "SendingStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SendingStatuses",
                table: "SendingStatuses");

            migrationBuilder.DropIndex(
                name: "IX_SendingStatuses_PostalItemId",
                table: "SendingStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostalItems",
                table: "PostalItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SendingStatuses");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PostalItems",
                newName: "PostalItem",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Contractors",
                newName: "Contractor",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Contractors_PositionId",
                schema: "dbo",
                table: "Contractor",
                newName: "IX_Contractor_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                schema: "dbo",
                table: "Address",
                newName: "IX_Address_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "SendingStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SendingContractorId",
                table: "SendingStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SendingAddressId",
                table: "SendingStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecievingContractorId",
                table: "SendingStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecievingAddressId",
                table: "SendingStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostalItemId",
                table: "SendingStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalItemId1",
                table: "SendingStatuses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Status",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "PostalItem",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Position",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                schema: "dbo",
                table: "Contractor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Contractor",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "City",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                schema: "dbo",
                table: "Address",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                schema: "dbo",
                table: "Address",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendingStatuses",
                table: "SendingStatuses",
                columns: new[] { "PostalItemId", "UpdateStatusDateTime", "StatusId", "SendingContractorId", "SendingAddressId", "RecievingContractorId", "RecievingAddressId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                schema: "dbo",
                table: "Status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostalItem",
                schema: "dbo",
                table: "PostalItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                schema: "dbo",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractor",
                schema: "dbo",
                table: "Contractor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                schema: "dbo",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatuses_PostalItemId1",
                table: "SendingStatuses",
                column: "PostalItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_PostalItem_PostalItemId1",
                table: "SendingStatuses",
                column: "PostalItemId1",
                principalSchema: "dbo",
                principalTable: "PostalItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Address_RecievingAddressId",
                table: "SendingStatuses",
                column: "RecievingAddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Contractor_RecievingContractorId",
                table: "SendingStatuses",
                column: "RecievingContractorId",
                principalSchema: "dbo",
                principalTable: "Contractor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Address_SendingAddressId",
                table: "SendingStatuses",
                column: "SendingAddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Contractor_SendingContractorId",
                table: "SendingStatuses",
                column: "SendingContractorId",
                principalSchema: "dbo",
                principalTable: "Contractor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Status_StatusId",
                table: "SendingStatuses",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                schema: "dbo",
                table: "Address",
                column: "CityId",
                principalSchema: "dbo",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_Position_PositionId",
                schema: "dbo",
                table: "Contractor",
                column: "PositionId",
                principalSchema: "dbo",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_PostalItem_PostalItemId1",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Address_RecievingAddressId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Contractor_RecievingContractorId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Address_SendingAddressId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Contractor_SendingContractorId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingStatuses_Status_StatusId",
                table: "SendingStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_Position_PositionId",
                schema: "dbo",
                table: "Contractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SendingStatuses",
                table: "SendingStatuses");

            migrationBuilder.DropIndex(
                name: "IX_SendingStatuses_PostalItemId1",
                table: "SendingStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                schema: "dbo",
                table: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostalItem",
                schema: "dbo",
                table: "PostalItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                schema: "dbo",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractor",
                schema: "dbo",
                table: "Contractor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PostalItemId1",
                table: "SendingStatuses");

            migrationBuilder.RenameTable(
                name: "Status",
                schema: "dbo",
                newName: "Statuses");

            migrationBuilder.RenameTable(
                name: "PostalItem",
                schema: "dbo",
                newName: "PostalItems");

            migrationBuilder.RenameTable(
                name: "Position",
                schema: "dbo",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "Contractor",
                schema: "dbo",
                newName: "Contractors");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "dbo",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "dbo",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Contractor_PositionId",
                table: "Contractors",
                newName: "IX_Contractors_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "RecievingAddressId",
                table: "SendingStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecievingContractorId",
                table: "SendingStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SendingAddressId",
                table: "SendingStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SendingContractorId",
                table: "SendingStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "SendingStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PostalItemId",
                table: "SendingStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SendingStatuses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PostalItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Contractors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contractors",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendingStatuses",
                table: "SendingStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostalItems",
                table: "PostalItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatuses_PostalItemId",
                table: "SendingStatuses",
                column: "PostalItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_Positions_PositionId",
                table: "Contractors",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_PostalItems_PostalItemId",
                table: "SendingStatuses",
                column: "PostalItemId",
                principalTable: "PostalItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Addresses_RecievingAddressId",
                table: "SendingStatuses",
                column: "RecievingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Contractors_RecievingContractorId",
                table: "SendingStatuses",
                column: "RecievingContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Addresses_SendingAddressId",
                table: "SendingStatuses",
                column: "SendingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Contractors_SendingContractorId",
                table: "SendingStatuses",
                column: "SendingContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingStatuses_Statuses_StatusId",
                table: "SendingStatuses",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
