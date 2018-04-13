using MVCMusicStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.DTOs
{
    public class AlbumDTO
    {
        public Guid AlbumId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public ICollection<ArtistDTO> Artists { get; set; }
        public GenreDTO AlbumGenre { get; set; }
    }
}
