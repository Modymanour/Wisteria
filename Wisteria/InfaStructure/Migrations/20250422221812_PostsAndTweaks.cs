using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wisteria.Migrations
{
    /// <inheritdoc />
    public partial class PostsAndTweaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostsPost_ID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Post_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "varchar(500)", nullable: true),
                    Bio = table.Column<string>(type: "varchar(300)", nullable: true),
                    Music_Track = table.Column<string>(type: "varchar(300)", nullable: true),
                    Img = table.Column<string>(type: "varchar(300)", nullable: true),
                    CommunitiesCommunity_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Post_ID);
                    table.ForeignKey(
                        name: "FK_Posts_Communities_CommunitiesCommunity_Id",
                        column: x => x.CommunitiesCommunity_Id,
                        principalTable: "Communities",
                        principalColumn: "Community_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostsPost_ID",
                table: "Comments",
                column: "PostsPost_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommunitiesCommunity_Id",
                table: "Posts",
                column: "CommunitiesCommunity_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostsPost_ID",
                table: "Comments",
                column: "PostsPost_ID",
                principalTable: "Posts",
                principalColumn: "Post_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostsPost_ID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostsPost_ID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostsPost_ID",
                table: "Comments");
        }
    }
}
