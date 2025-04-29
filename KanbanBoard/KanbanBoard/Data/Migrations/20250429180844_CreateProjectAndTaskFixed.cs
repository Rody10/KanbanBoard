using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanBoard.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateProjectAndTaskFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjectOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_ProjectOwnerId",
                        column: x => x.ProjectOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanbanBoardTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskAssignedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanBoardTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_KanbanBoardTasks_AspNetUsers_TaskAssignedUserId",
                        column: x => x.TaskAssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanbanBoardTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KanbanBoardTasks_ProjectId",
                table: "KanbanBoardTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanBoardTasks_TaskAssignedUserId",
                table: "KanbanBoardTasks",
                column: "TaskAssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectOwnerId",
                table: "Projects",
                column: "ProjectOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KanbanBoardTasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
