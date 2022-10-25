using Microsoft.EntityFrameworkCore.Migrations;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.SqlServer.Migrations.Identity
{
    public partial class CorporationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId",
                table: "org_Parties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CorporationUserIdentity",
                columns: table => new
                {
                    CorporationsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporationUserIdentity", x => new { x.CorporationsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CorporationUserIdentity_org_Corporations_CorporationsId",
                        column: x => x.CorporationsId,
                        principalTable: "org_Corporations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporationUserIdentity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_org_Parties_UserIdentityId",
                table: "org_Parties",
                column: "UserIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporationUserIdentity_UsersId",
                table: "CorporationUserIdentity",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_org_Parties_Users_UserIdentityId",
                table: "org_Parties",
                column: "UserIdentityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_org_Parties_Users_UserIdentityId",
                table: "org_Parties");

            migrationBuilder.DropTable(
                name: "CorporationUserIdentity");

            migrationBuilder.DropIndex(
                name: "IX_org_Parties_UserIdentityId",
                table: "org_Parties");

            migrationBuilder.DropColumn(
                name: "UserIdentityId",
                table: "org_Parties");
        }
    }
}
