using MVCMusicStore.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Interfaces
{
    public interface IGenreService
    {
        Task<GenreDTO> GetGenreAsync(Guid id);
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task CreateGenreAsync(GenreDTO genre);
        Task UpdateGenreAsync(GenreDTO genre);
        Task RemoveGenreAsync(Guid id);
    }
}
