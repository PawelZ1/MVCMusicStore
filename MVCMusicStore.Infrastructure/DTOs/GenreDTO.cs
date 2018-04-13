using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.DTOs
{
    public class GenreDTO
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<AlbumDTO> Albums { get; set; }
    }
}
