using Microsoft.EntityFrameworkCore.Migrations;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.MySql.Migrations.IdentityServerGrants
{
    public partial class CorporationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "PersistedGrants",
                type: "longtext",
                maxLength: 50000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldMaxLength: 50000);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "DeviceCodes",
                type: "longtext",
                maxLength: 50000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldMaxLength: 50000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "PersistedGrants",
                type: "longtext CHARACTER SET utf8mb4",
                maxLength: 50000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 50000);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "DeviceCodes",
                type: "longtext CHARACTER SET utf8mb4",
                maxLength: 50000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 50000);
        }
    }
}
