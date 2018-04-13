using MVCMusicStore.Core.Interfaces;
using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.DTOs;
using MVCMusicStore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task CreateAlbumAsync(AlbumDTO album)
        {
            if (album == null)
                throw new ArgumentNullException();

            Album albumToAdd = new Album(album.AlbumId, album.Title, album.Price);
            await _albumRepository.AddAsync(albumToAdd);
            
        }

        public async Task<AlbumDTO> GetAlbumAsync(Guid id)
        {
            Album album = await _albumRepository.GetAsync(id);

            return new AlbumDTO
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                Price = album.Price,
                Artists = album.Artists.Select(s => new ArtistDTO {
                    ArtistId = s.ArtistId,
                    Name = s.Name,
                    Country = s.Country
                }).ToList()
            };
        }

        public async Task<IEnumerable<AlbumDTO>> GetAllAlbumAsync()
        {
            IEnumerable<Album> albums = await _albumRepository.GetAllAsync();
            IEnumerable<AlbumDTO> albumsDTO = albums.Select(s => new AlbumDTO
            {
                AlbumId = s.AlbumId,
                Title = s.Title,
                Price = s.Price,
                Artists = s.Artists.Select(p => new ArtistDTO
                {
                    ArtistId = p.ArtistId,
                    Name = p.Name,
                    Country = p.Country
                }).ToList(),
                AlbumGenre = new GenreDTO
                {
                    GenreId = s.Genre.GenreId,
                    Name = s.Genre.Name
                }
            });
            return albumsDTO;
        }

        public Task RemoveAlbumtAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAlbumAsync(AlbumDTO album)
        {
            if (album == null)
                throw new ArgumentNullException();

            Album albumToUpdate = new Album(album.AlbumId, album.Title, album.Price);
            await _albumRepository.UpdateAsync(albumToUpdate);
        }
    }
}
