using MVCMusicStore.Core.Interfaces;
using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MVCMusicStoreDBContext _context;

        public GenreRepository(MVCMusicStoreDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Genre genre = await _context.Genres.SingleOrDefaultAsync(s => s.GenreId == id);
            if (genre == null)
                throw new ArgumentException();
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetAsync(Guid id)
        {
            return await _context.Genres.Include(s => s.Albums).SingleOrDefaultAsync(s => s.GenreId == id);
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
