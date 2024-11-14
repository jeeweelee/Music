using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSong { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
                modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });


                modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);

    
                modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);            
            // Seed Album data
            modelBuilder.Entity<Album>().HasData(
                new Album { Id = Guid.Parse("a1a1a1a1-1111-1111-1111-111111111111"), Name = "Spiritbox", CoverImage = null },
                new Album { Id = Guid.Parse("b2b2b2b2-2222-2222-2222-222222222222"), Name = "Canyon", CoverImage = null },
                new Album { Id = Guid.Parse("c3c3c3c3-3333-3333-3333-333333333333"), Name = "Single", CoverImage = null },
                new Album { Id = Guid.Parse("d4d4d4d4-4444-4444-4444-444444444444"), Name = "I Love You.", CoverImage = null },
                new Album { Id = Guid.Parse("e5e5e5e5-5555-5555-5555-555555555555"), Name = "When We All Fall Asleep, Where Do We Go?", CoverImage = null },
                new Album { Id = Guid.Parse("f6f6f6f6-6666-6666-6666-666666666666"), Name = "The Great Escape", CoverImage = null },
                new Album { Id = Guid.Parse("a17ca4a7-7c7c-7a7a-7a7a-777777777777"), Name = "Twelve Carat Toothache", CoverImage = null }
            );

            // Seed Song data with AlbumId foreign keys
            modelBuilder.Entity<Song>().HasData(
                new Song { Id = Guid.Parse("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"), Title = "Circle With Me", Artist = "Spiritbox", Genre = "Metal", AlbumId = Guid.Parse("a1a1a1a1-1111-1111-1111-111111111111") },
                new Song { Id = Guid.Parse("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"), Title = "Notes on a River Town", Artist = "Pony Bradshaw", Genre = "Folk", AlbumId = Guid.Parse("b2b2b2b2-2222-2222-2222-222222222222") },
                new Song { Id = Guid.Parse("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"), Title = "Flower Shops", Artist = "Morgan Allen", Genre = "Country", AlbumId = Guid.Parse("c3c3c3c3-3333-3333-3333-333333333333") },
                new Song { Id = Guid.Parse("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"), Title = "Sweater Weather", Artist = "The Neighbourhood", Genre = "Alternative", AlbumId = Guid.Parse("d4d4d4d4-4444-4444-4444-444444444444") },
                new Song { Id = Guid.Parse("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"), Title = "When the Party's Over", Artist = "Billie Eilish", Genre = "Pop", AlbumId = Guid.Parse("e5e5e5e5-5555-5555-5555-555555555555") },
                new Song { Id = Guid.Parse("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"), Title = "Utah", Artist = "French Cassettes", Genre = "Indie", AlbumId = Guid.Parse("f6f6f6f6-6666-6666-6666-666666666666") },
                new Song { Id = Guid.Parse("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"), Title = "Something Real", Artist = "Post Malone", Genre = "Hip Hop", AlbumId = Guid.Parse("a17ca4a7-7c7c-7a7a-7a7a-777777777777") }
            );
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { Id = Guid.Parse("5f2a1b29-93d2-4f89-b52d-77a507314b8e"), Name = "Testing1" },
                new Playlist { Id = Guid.Parse("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"), Name = "Testing2" },
                new Playlist { Id = Guid.Parse("c0439fbb-c5ad-4dcd-aa84-b5468634459e"), Name = "Testing3" }  
            );
            modelBuilder.Entity<PlaylistSong>().HasData(
                new PlaylistSong { PlaylistId = Guid.Parse("5f2a1b29-93d2-4f89-b52d-77a507314b8e"), SongId = Guid.Parse("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3") }, 
                new PlaylistSong { PlaylistId = Guid.Parse("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"), SongId = Guid.Parse("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45") }, 
                new PlaylistSong { PlaylistId = Guid.Parse("c0439fbb-c5ad-4dcd-aa84-b5468634459e"), SongId = Guid.Parse("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41") },
                new PlaylistSong { PlaylistId = Guid.Parse("7a4b3f1e-6cbb-4a93-8a39-31cba9d2dbf2"), SongId = Guid.Parse("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41") }  
            );

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
