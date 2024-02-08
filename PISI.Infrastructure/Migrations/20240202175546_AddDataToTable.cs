using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PISI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Subscribe",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ServiceUser",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "TokenExpiry",
                table: "ServiceUser",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "ServiceUser",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<string>(
                name: "ServiceId",
                table: "ServiceUser",
                type: "longtext",
                nullable: false);

            migrationBuilder.InsertData(
                table: "ServiceUser",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Password", "ServiceId", "Token", "TokenExpiry", "UpdatedBy" },
                values: new object[] { 1L, "ID-2345", new DateTime(2024, 2, 2, 18, 55, 46, 505, DateTimeKind.Local).AddTicks(82), null, "W@ke123", "ID-2345", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceUser",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServiceUser");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Subscribe",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ServiceUser",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TokenExpiry",
                table: "ServiceUser",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "ServiceUser",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);
        }
    }
}
