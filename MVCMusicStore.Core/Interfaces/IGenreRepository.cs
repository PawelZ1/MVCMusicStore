using MVCMusicStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Interfaces
{
    public interface IGenreRepository
    {
        Task AddAsync(Genre genre);
        Task<Genre> GetAsync(Guid id);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(Guid id);
    }
}
