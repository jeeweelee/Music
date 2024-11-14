using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace music_manager_starter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Songs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSong",
                columns: table => new
                {
                    PlaylistId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SongId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSong", x => new { x.PlaylistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5f2a1b29-93d2-4f89-b52d-77a507314b8e"), "Testing1" },
                    { new Guid("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"), "Testing2" },
                    { new Guid("c0439fbb-c5ad-4dcd-aa84-b5468634459e"), "Testing3" }
                });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"),
                column: "ReleaseDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"),
                column: "ReleaseDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"),
                column: "ReleaseDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"),
                column: "ReleaseDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"),
                column: "ReleaseDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"),
                column: "ReleaseDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"),
                column: "ReleaseDate",
                value: null);

            migrationBuilder.InsertData(
                table: "PlaylistSong",
                columns: new[] { "PlaylistId", "SongId" },
                values: new object[,]
                {
                    { new Guid("5f2a1b29-93d2-4f89-b52d-77a507314b8e"), new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3") },
                    { new Guid("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"), new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45") },
                    { new Guid("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"), new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41") },
                    { new Guid("c0439fbb-c5ad-4dcd-aa84-b5468634459e"), new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_SongId",
                table: "PlaylistSong",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistSong");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Songs");
        }
    }
}
