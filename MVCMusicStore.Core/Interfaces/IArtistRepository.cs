using MVCMusicStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artist> GetAsync(Guid id);
        Task<IEnumerable<Artist>> GetAllAsync();
        Task AddAsync(Artist artist);
        Task UpdateAsync(Artist artist);
        Task DeleteAsync(Guid id);
    }
}
