using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wisteria.Migrations
{
    /// <inheritdoc />
    public partial class AddCommunities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Community_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Community_Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunitiesUser",
                columns: table => new
                {
                    Community_MembersUser_ID = table.Column<int>(type: "int", nullable: false),
                    Joined_CommunitiesCommunity_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitiesUser", x => new { x.Community_MembersUser_ID, x.Joined_CommunitiesCommunity_Id });
                    table.ForeignKey(
                        name: "FK_CommunitiesUser_Communities_Joined_CommunitiesCommunity_Id",
                        column: x => x.Joined_CommunitiesCommunity_Id,
                        principalTable: "Communities",
                        principalColumn: "Community_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunitiesUser_Users_Community_MembersUser_ID",
                        column: x => x.Community_MembersUser_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesUser_Joined_CommunitiesCommunity_Id",
                table: "CommunitiesUser",
                column: "Joined_CommunitiesCommunity_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunitiesUser");

            migrationBuilder.DropTable(
                name: "Communities");
        }
    }
}
