using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;
using System.Text.Json;

namespace music_manager_starter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistSongController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistSongController(DataDbContext context)
        {
            _context = context;
        }
        [HttpPost("add")] // Add a song to a playlist
        public async Task<IActionResult> AddSongToPlaylist([FromBody] JsonElement data)
        {
            try
            {
                var playlistId = Guid.Parse(data.GetProperty("playlistId").GetString());
                var songId = Guid.Parse(data.GetProperty("songId").GetString());

                var playlist = await _context.Playlists.FindAsync(playlistId);
                if (playlist == null)
                {
                    return NotFound(new { Message = "Playlist not found." });
                }

                var song = await _context.Songs.FindAsync(songId);
                if (song == null)
                {
                    return NotFound(new { Message = "Song not found." });
                }

                // if song already exist then do this
                var existingEntry = await _context.PlaylistSong
                .FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);
                if (existingEntry != null)
                {
                    return Conflict(new { Message = "Song is already in the playlist." });
                }

                var playlistSong = new PlaylistSong
                {
                    PlaylistId = playlistId,
                    SongId = songId
                };

                _context.PlaylistSong.Add(playlistSong);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Song added to playlist successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Invalid request data.", Error = ex.Message });
            }
        }


        [HttpDelete("{playlistId}/{songId}")]   //Delete a song from a playlist
        public async Task<IActionResult> DeleteSongFromPlaylist(Guid playlistId, Guid songId)
        {
            var playlistSong = await _context.PlaylistSong
                .FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);

            if (playlistSong == null)
            {
                return NotFound(new { Message = "Song not found in the specified playlist." });
            }

            _context.PlaylistSong.Remove(playlistSong);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
