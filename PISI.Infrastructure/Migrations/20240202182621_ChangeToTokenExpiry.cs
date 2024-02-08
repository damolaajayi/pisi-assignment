using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PISI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToTokenExpiry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TokenExpiry",
                table: "ServiceUser",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ServiceUser",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "TokenExpiry" },
                values: new object[] { new DateTime(2024, 2, 2, 19, 26, 21, 660, DateTimeKind.Local).AddTicks(1860), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TokenExpiry",
                table: "ServiceUser",
                type: "double",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ServiceUser",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "TokenExpiry" },
                values: new object[] { new DateTime(2024, 2, 2, 18, 55, 46, 505, DateTimeKind.Local).AddTicks(82), null });
        }
    }
}
