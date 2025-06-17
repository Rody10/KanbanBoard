using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanBoard.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectIDFKToTaskAddedProjectsNavigationPropertyToUserDisabledCascadeDeletionFromUserToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanBoardTasks_Projects_ProjectId",
                table: "KanbanBoardTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "KanbanBoardTasks",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanBoardTasks_ProjectId",
                table: "KanbanBoardTasks",
                newName: "IX_KanbanBoardTasks_ProjectID");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "KanbanBoardTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanBoardTasks_Projects_ProjectID",
                table: "KanbanBoardTasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects",
                column: "ProjectOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanBoardTasks_Projects_ProjectID",
                table: "KanbanBoardTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "KanbanBoardTasks",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanBoardTasks_ProjectID",
                table: "KanbanBoardTasks",
                newName: "IX_KanbanBoardTasks_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "KanbanBoardTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanBoardTasks_Projects_ProjectId",
                table: "KanbanBoardTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                table: "Projects",
                column: "ProjectOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
