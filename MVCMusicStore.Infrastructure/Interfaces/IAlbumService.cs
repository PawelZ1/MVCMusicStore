using MVCMusicStore.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Interfaces
{
    public interface IAlbumService
    {
        Task<AlbumDTO> GetAlbumAsync(Guid id);
        Task<IEnumerable<AlbumDTO>> GetAllAlbumAsync();
        Task CreateAlbumAsync(AlbumDTO album);
        Task UpdateAlbumAsync(AlbumDTO album);
        Task RemoveAlbumtAsync(Guid id);
    }
}
