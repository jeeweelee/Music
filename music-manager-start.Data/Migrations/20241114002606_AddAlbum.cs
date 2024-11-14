using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace music_manager_starter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Album",
                table: "Songs",
                newName: "AlbumId");

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CoverImage = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CoverImage", "Name" },
                values: new object[,]
                {
                    { new Guid("a17ca4a7-7c7c-7a7a-7a7a-777777777777"), null, "Twelve Carat Toothache" },
                    { new Guid("a1a1a1a1-1111-1111-1111-111111111111"), null, "Spiritbox" },
                    { new Guid("b2b2b2b2-2222-2222-2222-222222222222"), null, "Canyon" },
                    { new Guid("c3c3c3c3-3333-3333-3333-333333333333"), null, "Single" },
                    { new Guid("d4d4d4d4-4444-4444-4444-444444444444"), null, "I Love You." },
                    { new Guid("e5e5e5e5-5555-5555-5555-555555555555"), null, "When We All Fall Asleep, Where Do We Go?" },
                    { new Guid("f6f6f6f6-6666-6666-6666-666666666666"), null, "The Great Escape" }
                });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"),
                column: "AlbumId",
                value: new Guid("a17ca4a7-7c7c-7a7a-7a7a-777777777777"));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"),
                column: "AlbumId",
                value: new Guid("b2b2b2b2-2222-2222-2222-222222222222"));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"),
                column: "AlbumId",
                value: new Guid("e5e5e5e5-5555-5555-5555-555555555555"));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"),
                column: "AlbumId",
                value: new Guid("a1a1a1a1-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"),
                column: "AlbumId",
                value: new Guid("f6f6f6f6-6666-6666-6666-666666666666"));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"),
                column: "AlbumId",
                value: new Guid("d4d4d4d4-4444-4444-4444-444444444444"));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"),
                column: "AlbumId",
                value: new Guid("c3c3c3c3-3333-3333-3333-333333333333"));

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Songs",
                newName: "Album");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"),
                column: "Album",
                value: "Twelve Carat Toothache");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"),
                column: "Album",
                value: "Canyon");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"),
                column: "Album",
                value: "When We All Fall Asleep, Where Do We Go?");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"),
                column: "Album",
                value: "Spiritbox");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"),
                column: "Album",
                value: "The Great Escape");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"),
                column: "Album",
                value: "I Love You.");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"),
                column: "Album",
                value: "Single");
        }
    }
}
