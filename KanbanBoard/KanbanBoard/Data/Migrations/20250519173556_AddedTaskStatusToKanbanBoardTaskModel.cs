using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanBoard.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTaskStatusToKanbanBoardTaskModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskStatus",
                table: "KanbanBoardTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskStatus",
                table: "KanbanBoardTasks");
        }
    }
}
