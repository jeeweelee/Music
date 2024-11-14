﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using music_manager_starter.Data;

#nullable disable

namespace music_manager_starter.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20241114004235_AddPlaylist")]
    partial class AddPlaylist
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("music_manager_starter.Data.Models.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("CoverImage")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1a1a1a1-1111-1111-1111-111111111111"),
                            Name = "Spiritbox"
                        },
                        new
                        {
                            Id = new Guid("b2b2b2b2-2222-2222-2222-222222222222"),
                            Name = "Canyon"
                        },
                        new
                        {
                            Id = new Guid("c3c3c3c3-3333-3333-3333-333333333333"),
                            Name = "Single"
                        },
                        new
                        {
                            Id = new Guid("d4d4d4d4-4444-4444-4444-444444444444"),
                            Name = "I Love You."
                        },
                        new
                        {
                            Id = new Guid("e5e5e5e5-5555-5555-5555-555555555555"),
                            Name = "When We All Fall Asleep, Where Do We Go?"
                        },
                        new
                        {
                            Id = new Guid("f6f6f6f6-6666-6666-6666-666666666666"),
                            Name = "The Great Escape"
                        },
                        new
                        {
                            Id = new Guid("a17ca4a7-7c7c-7a7a-7a7a-777777777777"),
                            Name = "Twelve Carat Toothache"
                        });
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5f2a1b29-93d2-4f89-b52d-77a507314b8e"),
                            Name = "Testing1"
                        },
                        new
                        {
                            Id = new Guid("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"),
                            Name = "Testing2"
                        },
                        new
                        {
                            Id = new Guid("c0439fbb-c5ad-4dcd-aa84-b5468634459e"),
                            Name = "Testing3"
                        });
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.PlaylistSong", b =>
                {
                    b.Property<Guid>("PlaylistId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SongId")
                        .HasColumnType("TEXT");

                    b.HasKey("PlaylistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSong");

                    b.HasData(
                        new
                        {
                            PlaylistId = new Guid("5f2a1b29-93d2-4f89-b52d-77a507314b8e"),
                            SongId = new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3")
                        },
                        new
                        {
                            PlaylistId = new Guid("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"),
                            SongId = new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45")
                        },
                        new
                        {
                            PlaylistId = new Guid("c0439fbb-c5ad-4dcd-aa84-b5468634459e"),
                            SongId = new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41")
                        },
                        new
                        {
                            PlaylistId = new Guid("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"),
                            SongId = new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41")
                        });
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"),
                            AlbumId = new Guid("a1a1a1a1-1111-1111-1111-111111111111"),
                            Artist = "Spiritbox",
                            Genre = "Metal",
                            Title = "Circle With Me"
                        },
                        new
                        {
                            Id = new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"),
                            AlbumId = new Guid("b2b2b2b2-2222-2222-2222-222222222222"),
                            Artist = "Pony Bradshaw",
                            Genre = "Folk",
                            Title = "Notes on a River Town"
                        },
                        new
                        {
                            Id = new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"),
                            AlbumId = new Guid("c3c3c3c3-3333-3333-3333-333333333333"),
                            Artist = "Morgan Allen",
                            Genre = "Country",
                            Title = "Flower Shops"
                        },
                        new
                        {
                            Id = new Guid("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"),
                            AlbumId = new Guid("d4d4d4d4-4444-4444-4444-444444444444"),
                            Artist = "The Neighbourhood",
                            Genre = "Alternative",
                            Title = "Sweater Weather"
                        },
                        new
                        {
                            Id = new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"),
                            AlbumId = new Guid("e5e5e5e5-5555-5555-5555-555555555555"),
                            Artist = "Billie Eilish",
                            Genre = "Pop",
                            Title = "When the Party's Over"
                        },
                        new
                        {
                            Id = new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"),
                            AlbumId = new Guid("f6f6f6f6-6666-6666-6666-666666666666"),
                            Artist = "French Cassettes",
                            Genre = "Indie",
                            Title = "Utah"
                        },
                        new
                        {
                            Id = new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"),
                            AlbumId = new Guid("a17ca4a7-7c7c-7a7a-7a7a-777777777777"),
                            Artist = "Post Malone",
                            Genre = "Hip Hop",
                            Title = "Something Real"
                        });
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.PlaylistSong", b =>
                {
                    b.HasOne("music_manager_starter.Data.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("music_manager_starter.Data.Models.Song", "Song")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Song", b =>
                {
                    b.HasOne("music_manager_starter.Data.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("music_manager_starter.Data.Models.Song", b =>
                {
                    b.Navigation("PlaylistSongs");
                });
#pragma warning restore 612, 618
        }
    }
}
