using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace music_manager_starter.Data.Models
{
    public class SongRating
    {
        public Guid Id { get; set; } // Unique identifier for the rating

        [Required]
        public Guid SongId { get; set; } // The song being rated

        [Required]
        [Range(1, 5)] // Rating range from 1 to 5
        public int Rating { get; set; } // User's rating of the song
        public Song Song { get; set; } // Navigation property to the Song model
    }
}
