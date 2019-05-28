using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OPID",
                table: "Post",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OPID",
                table: "Post",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
