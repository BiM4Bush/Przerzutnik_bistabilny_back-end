using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.Migrations
{
    public partial class Migrate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Column_Kanban_KanbanPostKanbanId",
                table: "Column");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Kanban_KanbanPostKanbanId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_KanbanPostKanbanId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Column_KanbanPostKanbanId",
                table: "Column");

            migrationBuilder.DropColumn(
                name: "KanbanPostKanbanId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "KanbanPostKanbanId",
                table: "Column");

            migrationBuilder.AddColumn<int>(
                name: "KanbanBoardKanbanId",
                table: "Note",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KanbanBoardKanbanId",
                table: "Column",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_KanbanBoardKanbanId",
                table: "Note",
                column: "KanbanBoardKanbanId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_KanbanBoardKanbanId",
                table: "Column",
                column: "KanbanBoardKanbanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Column_Kanban_KanbanBoardKanbanId",
                table: "Column",
                column: "KanbanBoardKanbanId",
                principalTable: "Kanban",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Kanban_KanbanBoardKanbanId",
                table: "Note",
                column: "KanbanBoardKanbanId",
                principalTable: "Kanban",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Column_Kanban_KanbanBoardKanbanId",
                table: "Column");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Kanban_KanbanBoardKanbanId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_KanbanBoardKanbanId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Column_KanbanBoardKanbanId",
                table: "Column");

            migrationBuilder.DropColumn(
                name: "KanbanBoardKanbanId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "KanbanBoardKanbanId",
                table: "Column");

            migrationBuilder.AddColumn<int>(
                name: "KanbanPostKanbanId",
                table: "Note",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KanbanPostKanbanId",
                table: "Column",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_KanbanPostKanbanId",
                table: "Note",
                column: "KanbanPostKanbanId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_KanbanPostKanbanId",
                table: "Column",
                column: "KanbanPostKanbanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Column_Kanban_KanbanPostKanbanId",
                table: "Column",
                column: "KanbanPostKanbanId",
                principalTable: "Kanban",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Kanban_KanbanPostKanbanId",
                table: "Note",
                column: "KanbanPostKanbanId",
                principalTable: "Kanban",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
