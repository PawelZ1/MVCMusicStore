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
    class ArtistRepository : IArtistRepository
    {
        private readonly MVCMusicStoreDBContext _context;

        public ArtistRepository(MVCMusicStoreDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Artist artist)
        {
            if (artist == null)
                throw new ArgumentNullException();
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException();
            var artist = await _context.Artists.SingleOrDefaultAsync(x => x.ArtistId == id);
            if (artist == null)
                throw new ArgumentException();
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetAsync(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException();
            return await _context.Artists.SingleOrDefaultAsync(x => x.ArtistId == id);
        }

        public async Task UpdateAsync(Artist artist)
        {
            if (artist == null)
                throw new ArgumentNullException();
            _context.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
