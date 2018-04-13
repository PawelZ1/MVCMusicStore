using MVCMusicStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Interfaces
{
    public interface IAlbumRepository
    {
        Task AddAsync(Album album);
        Task<Album> GetAsync(Guid id);
        Task<IEnumerable<Album>> GetAllAsync();
        Task UpdateAsync(Album album);
        Task DeleleAsync(Guid id);
    }
}
