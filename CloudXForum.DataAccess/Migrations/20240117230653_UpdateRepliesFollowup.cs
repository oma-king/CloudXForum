using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudXForum.DataAccess.Migrations
{
    public partial class UpdateRepliesFollowup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RepliesFollowup",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RepliesFollowup_UserId",
                table: "RepliesFollowup",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepliesFollowup_AspNetUsers_UserId",
                table: "RepliesFollowup",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepliesFollowup_AspNetUsers_UserId",
                table: "RepliesFollowup");

            migrationBuilder.DropIndex(
                name: "IX_RepliesFollowup_UserId",
                table: "RepliesFollowup");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RepliesFollowup");
        }
    }
}
