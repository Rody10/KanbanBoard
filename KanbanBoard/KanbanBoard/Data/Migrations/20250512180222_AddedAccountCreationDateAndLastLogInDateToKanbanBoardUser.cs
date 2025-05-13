using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanBoard.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountCreationDateAndLastLogInDateToKanbanBoardUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "AccountCreationDate",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastLogInDate",
                table: "AspNetUsers",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountCreationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLogInDate",
                table: "AspNetUsers");
        }
    }
}
