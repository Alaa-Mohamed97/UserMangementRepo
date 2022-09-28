using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementWithUOW.EF.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificationsUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Certifications",
                newName: "CertificationsId");

            migrationBuilder.CreateTable(
                name: "UsersCretifications",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CertificationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCretifications", x => new { x.UserId, x.CertificationsId });
                    table.ForeignKey(
                        name: "FK_UsersCretifications_Certifications_CertificationsId",
                        column: x => x.CertificationsId,
                        principalTable: "Certifications",
                        principalColumn: "CertificationsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCretifications_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersCretifications_CertificationsId",
                table: "UsersCretifications",
                column: "CertificationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersCretifications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CertificationsId",
                table: "Certifications",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "CertificationsUser",
                columns: table => new
                {
                    CertificationsId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationsUser", x => new { x.CertificationsId, x.usersId });
                    table.ForeignKey(
                        name: "FK_CertificationsUser_Certifications_CertificationsId",
                        column: x => x.CertificationsId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationsUser_users_usersId",
                        column: x => x.usersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificationsUser_usersId",
                table: "CertificationsUser",
                column: "usersId");
        }
    }
}
