using Microsoft.EntityFrameworkCore.Migrations;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.SqlServer.Migrations.Identity
{
    public partial class AddMultipleTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "org_Corporations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCnt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org_Corporations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "org_Parties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenApiPartyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    PathIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pinyin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Py = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_org_Parties_org_Corporations_CorporationId",
                        column: x => x.CorporationId,
                        principalTable: "org_Corporations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "org_UserCorporations",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CorpId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org_UserCorporations", x => new { x.UserId, x.CorpId });
                    table.ForeignKey(
                        name: "FK_org_UserCorporations_org_Corporations_CorpId",
                        column: x => x.CorpId,
                        principalTable: "org_Corporations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_org_UserCorporations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "org_UserParties",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartyId = table.Column<long>(type: "bigint", nullable: false),
                    DisplayOrder = table.Column<long>(type: "bigint", nullable: false),
                    IsMainParty = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org_UserParties", x => new { x.UserId, x.PartyId });
                    table.ForeignKey(
                        name: "FK_org_UserParties_org_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "org_Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_org_UserParties_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_org_Parties_CorporationId",
                table: "org_Parties",
                column: "CorporationId");

            migrationBuilder.CreateIndex(
                name: "IX_org_UserCorporations_CorpId",
                table: "org_UserCorporations",
                column: "CorpId");

            migrationBuilder.CreateIndex(
                name: "IX_org_UserParties_PartyId",
                table: "org_UserParties",
                column: "PartyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "org_UserCorporations");

            migrationBuilder.DropTable(
                name: "org_UserParties");

            migrationBuilder.DropTable(
                name: "org_Parties");

            migrationBuilder.DropTable(
                name: "org_Corporations");
        }
    }
}
