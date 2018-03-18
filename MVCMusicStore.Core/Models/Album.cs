using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Models
{
    public class Album
    {
        public Guid AlbumId { get; private set; }
        public Guid GenreId { get; private set; }
        public Guid ArtistId { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
    }
}
