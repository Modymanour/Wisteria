using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wisteria.Migrations
{
    /// <inheritdoc />
    public partial class TazbeetRelationshipUserCommunities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUser_Communities_Joined_CommunitiesCommunity_Id",
                table: "CommunitiesUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunitiesUser",
                table: "CommunitiesUser");

            migrationBuilder.DropIndex(
                name: "IX_CommunitiesUser_Joined_CommunitiesCommunity_Id",
                table: "CommunitiesUser");

            migrationBuilder.RenameColumn(
                name: "Joined_CommunitiesCommunity_Id",
                table: "CommunitiesUser",
                newName: "CommunitiesCommunity_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Communities",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Communities",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunitiesUser",
                table: "CommunitiesUser",
                columns: new[] { "CommunitiesCommunity_Id", "Community_MembersUser_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesUser_Community_MembersUser_ID",
                table: "CommunitiesUser",
                column: "Community_MembersUser_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUser_Communities_CommunitiesCommunity_Id",
                table: "CommunitiesUser",
                column: "CommunitiesCommunity_Id",
                principalTable: "Communities",
                principalColumn: "Community_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUser_Communities_CommunitiesCommunity_Id",
                table: "CommunitiesUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunitiesUser",
                table: "CommunitiesUser");

            migrationBuilder.DropIndex(
                name: "IX_CommunitiesUser_Community_MembersUser_ID",
                table: "CommunitiesUser");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Communities");

            migrationBuilder.RenameColumn(
                name: "CommunitiesCommunity_Id",
                table: "CommunitiesUser",
                newName: "Joined_CommunitiesCommunity_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Communities",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunitiesUser",
                table: "CommunitiesUser",
                columns: new[] { "Community_MembersUser_ID", "Joined_CommunitiesCommunity_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesUser_Joined_CommunitiesCommunity_Id",
                table: "CommunitiesUser",
                column: "Joined_CommunitiesCommunity_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUser_Communities_Joined_CommunitiesCommunity_Id",
                table: "CommunitiesUser",
                column: "Joined_CommunitiesCommunity_Id",
                principalTable: "Communities",
                principalColumn: "Community_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
