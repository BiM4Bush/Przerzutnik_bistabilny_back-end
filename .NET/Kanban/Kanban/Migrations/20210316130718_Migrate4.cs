using Microsoft.EntityFrameworkCore.Migrations;

namespace Kanban.Migrations
{
    public partial class Migrate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kanban_Column_ColumnId",
                table: "Kanban");

            migrationBuilder.DropForeignKey(
                name: "FK_Kanban_Note_NoteId",
                table: "Kanban");

            migrationBuilder.DropIndex(
                name: "IX_Kanban_ColumnId",
                table: "Kanban");

            migrationBuilder.DropIndex(
                name: "IX_Kanban_NoteId",
                table: "Kanban");

            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "Kanban");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Kanban");

            migrationBuilder.AddColumn<int>(
                name: "KanbanPostKanbanId",
                table: "Note",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KanbanPostKanbanId",
                table: "Column",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ColumnId",
                table: "Kanban",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Kanban",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kanban_ColumnId",
                table: "Kanban",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Kanban_NoteId",
                table: "Kanban",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kanban_Column_ColumnId",
                table: "Kanban",
                column: "ColumnId",
                principalTable: "Column",
                principalColumn: "ColumnId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kanban_Note_NoteId",
                table: "Kanban",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "NoteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
