﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Tickets");
        }
    }
}
