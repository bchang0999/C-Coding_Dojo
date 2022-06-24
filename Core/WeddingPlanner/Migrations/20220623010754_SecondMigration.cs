using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Users_UserId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Wedding_WeddingId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedding_Users_UserId",
                table: "Wedding");

            migrationBuilder.DropTable(
                name: "Logusers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.RenameTable(
                name: "Wedding",
                newName: "Weddings");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.RenameIndex(
                name: "IX_Wedding_UserId",
                table: "Weddings",
                newName: "IX_Weddings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_WeddingId",
                table: "Guests",
                newName: "IX_Guests_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_UserId",
                table: "Guests",
                newName: "IX_Guests_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Users_UserId",
                table: "Guests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Users_UserId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.RenameTable(
                name: "Weddings",
                newName: "Wedding");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.RenameIndex(
                name: "IX_Weddings_UserId",
                table: "Wedding",
                newName: "IX_Wedding_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_WeddingId",
                table: "Guest",
                newName: "IX_Guest_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_UserId",
                table: "Guest",
                newName: "IX_Guest_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "GuestId");

            migrationBuilder.CreateTable(
                name: "Logusers",
                columns: table => new
                {
                    LoguserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logusers", x => x.LoguserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Users_UserId",
                table: "Guest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Wedding_WeddingId",
                table: "Guest",
                column: "WeddingId",
                principalTable: "Wedding",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wedding_Users_UserId",
                table: "Wedding",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
