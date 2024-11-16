using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace music_manager_starter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SongId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongRatings_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SongRatings",
                columns: new[] { "Id", "Rating", "SongId" },
                values: new object[,]
                {
                    { new Guid("2a0b9f42-3997-41e7-9a35-8363fa201606"), 5, new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3") },
                    { new Guid("8b7ff8ea-e16c-4ff6-8fdb-b8b0f4437f8e"), 4, new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongRatings_SongId",
                table: "SongRatings",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongRatings");
        }
    }
}
