using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet] //Get all playlist
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _context.Playlists.ToListAsync();
        }

        [HttpPost] //Add playlist
        public async Task<ActionResult<Playlist>> AddPlaylist(Playlist playlist)
        {
            
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetPlaylists), new { id = playlist.Id }, playlist);
        }
        [HttpPut("{id}")] //Edit a playlistName by ID, Editing song in other controller
        public async Task<IActionResult> UpdatePlaylistName(Guid id, [FromBody] Playlist playlist)
        {
            var existingPlaylist = await _context.Playlists.FindAsync(id);

            if (existingPlaylist == null)
            {
                return NotFound($"Playlist with ID {id} not found." );
            }

            existingPlaylist.Name = playlist.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred, could not update the playlist: {ex.Message}" );
            }

            return Ok($"Playlist Name updated {existingPlaylist.Name}");
        }

        [HttpDelete("{id}")] //Delete Playlist
        public async Task<IActionResult> DeletePlaylist(Guid id)
        {
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound($"Playlist with ID {id} not found." );
            }

            _context.Playlists.Remove(playlist);

            await _context.SaveChangesAsync();
            return Ok($"Playlist with ID {id} has been deleted." );
        }
    }
}