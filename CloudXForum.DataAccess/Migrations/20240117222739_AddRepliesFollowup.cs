using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudXForum.DataAccess.Migrations
{
    public partial class AddRepliesFollowup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepliesFollowup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    PostReplyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepliesFollowup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepliesFollowup_PostReplies_PostReplyId",
                        column: x => x.PostReplyId,
                        principalTable: "PostReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepliesFollowup_PostReplyId",
                table: "RepliesFollowup",
                column: "PostReplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepliesFollowup");
        }
    }
}
