using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudXForum.DataAccess.Migrations
{
    public partial class UpdatePostSubscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostSubscription_AspNetUsers_UserId",
                table: "PostSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_PostSubscription_Posts_PostId",
                table: "PostSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostSubscription",
                table: "PostSubscription");

            migrationBuilder.RenameTable(
                name: "PostSubscription",
                newName: "PostSubscriptions");

            migrationBuilder.RenameIndex(
                name: "IX_PostSubscription_UserId",
                table: "PostSubscriptions",
                newName: "IX_PostSubscriptions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostSubscription_PostId",
                table: "PostSubscriptions",
                newName: "IX_PostSubscriptions_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostSubscriptions",
                table: "PostSubscriptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostSubscriptions_AspNetUsers_UserId",
                table: "PostSubscriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostSubscriptions_Posts_PostId",
                table: "PostSubscriptions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostSubscriptions_AspNetUsers_UserId",
                table: "PostSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostSubscriptions_Posts_PostId",
                table: "PostSubscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostSubscriptions",
                table: "PostSubscriptions");

            migrationBuilder.RenameTable(
                name: "PostSubscriptions",
                newName: "PostSubscription");

            migrationBuilder.RenameIndex(
                name: "IX_PostSubscriptions_UserId",
                table: "PostSubscription",
                newName: "IX_PostSubscription_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostSubscriptions_PostId",
                table: "PostSubscription",
                newName: "IX_PostSubscription_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostSubscription",
                table: "PostSubscription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostSubscription_AspNetUsers_UserId",
                table: "PostSubscription",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostSubscription_Posts_PostId",
                table: "PostSubscription",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
