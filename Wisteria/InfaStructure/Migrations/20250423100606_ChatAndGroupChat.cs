using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wisteria.Migrations
{
    /// <inheritdoc />
    public partial class ChatAndGroupChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupChat",
                columns: table => new
                {
                    GroupChatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(400)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChat", x => x.GroupChatID);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Text_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    GroupChatID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Text_ID);
                    table.ForeignKey(
                        name: "FK_Chat_GroupChat_GroupChatID",
                        column: x => x.GroupChatID,
                        principalTable: "GroupChat",
                        principalColumn: "GroupChatID");
                });

            migrationBuilder.CreateTable(
                name: "GroupChatUser",
                columns: table => new
                {
                    groupChatsGroupChatID = table.Column<int>(type: "int", nullable: false),
                    usersUser_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatUser", x => new { x.groupChatsGroupChatID, x.usersUser_ID });
                    table.ForeignKey(
                        name: "FK_GroupChatUser_GroupChat_groupChatsGroupChatID",
                        column: x => x.groupChatsGroupChatID,
                        principalTable: "GroupChat",
                        principalColumn: "GroupChatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupChatUser_Users_usersUser_ID",
                        column: x => x.usersUser_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_GroupChatID",
                table: "Chat",
                column: "GroupChatID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatUser_usersUser_ID",
                table: "GroupChatUser",
                column: "usersUser_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "GroupChatUser");

            migrationBuilder.DropTable(
                name: "GroupChat");
        }
    }
}
