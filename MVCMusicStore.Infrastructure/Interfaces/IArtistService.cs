using MVCMusicStore.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Interfaces
{
    public interface IArtistService
    {
        Task<ArtistDTO> GetArtistAsync(Guid id);
        Task<IEnumerable<ArtistDTO>> GetAllArtistsAsync();
        Task CreateArtistAsync(ArtistDTO artist);
        Task UpdateArtistAsync(ArtistDTO artist);
        Task RemoveArtistAsync(Guid id);
    }
}
