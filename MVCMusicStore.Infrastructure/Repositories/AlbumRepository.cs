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
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MVCMusicStoreDBContext _context;

        public AlbumRepository(MVCMusicStoreDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Album album)
        {
            bool exists = await _context.Albums.AnyAsync(s => s.AlbumId == album.AlbumId);
            if (exists)
                throw new ArgumentException();
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
        }

        public async Task DeleleAsync(Guid id)
        {
            var album = await GetAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<Album> GetAsync(Guid id)
        {
            return await _context.Albums.Include(s => s.Artists).SingleOrDefaultAsync(s => s.AlbumId == id);
        }

        public async Task UpdateAsync(Album album)
        {
            bool exists = await _context.Albums.AnyAsync(s => s.AlbumId == album.AlbumId);
            if (!exists)
                throw new ArgumentException();

            _context.Entry(album).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
