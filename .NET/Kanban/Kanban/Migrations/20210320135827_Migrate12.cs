using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.Migrations
{
    public partial class Migrate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanban_User_OwneruserId",
                table: "Kanban");

            migrationBuilder.DropIndex(
                name: "IX_Kanban_OwneruserId",
                table: "Kanban");

            migrationBuilder.DropColumn(
                name: "OwneruserId",
                table: "Kanban");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwneruserId",
                table: "Kanban",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kanban_OwneruserId",
                table: "Kanban",
                column: "OwneruserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kanban_User_OwneruserId",
                table: "Kanban",
                column: "OwneruserId",
                principalTable: "User",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
