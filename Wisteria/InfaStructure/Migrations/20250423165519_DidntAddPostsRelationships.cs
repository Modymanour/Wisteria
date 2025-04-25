using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wisteria.Migrations
{
    /// <inheritdoc />
    public partial class DidntAddPostsRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_User_ID",
                table: "Posts",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_User_ID",
                table: "Posts",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "User_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_User_ID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_User_ID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Posts");
        }
    }
}
