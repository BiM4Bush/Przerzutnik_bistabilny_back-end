using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.Migrations
{
    public partial class Migrate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColumnId",
                table: "Note",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_ColumnId",
                table: "Note",
                column: "ColumnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Column_ColumnId",
                table: "Note",
                column: "ColumnId",
                principalTable: "Column",
                principalColumn: "ColumnId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Column_ColumnId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_ColumnId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "Note");
        }
    }
}
