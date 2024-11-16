using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace music_manager_starter.Shared
{
    public class SongRating
    {
        public Guid Id { get; set; } 

        [Required]
        public Guid SongId { get; set; } 

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; } 
        public Song Song { get; set; }
    }
}
