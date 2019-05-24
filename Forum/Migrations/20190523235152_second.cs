using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Post",
                newName: "OPID");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserID",
                table: "Post",
                newName: "IX_Post_OPID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comment",
                newName: "OPID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                newName: "IX_Comment_OPID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_OPID",
                table: "Comment",
                column: "OPID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_OPID",
                table: "Post",
                column: "OPID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_OPID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_OPID",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "OPID",
                table: "Post",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Post_OPID",
                table: "Post",
                newName: "IX_Post_UserID");

            migrationBuilder.RenameColumn(
                name: "OPID",
                table: "Comment",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OPID",
                table: "Comment",
                newName: "IX_Comment_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
