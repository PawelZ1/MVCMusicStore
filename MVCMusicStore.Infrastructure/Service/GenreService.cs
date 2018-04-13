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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task CreateGenreAsync(GenreDTO genre)
        {
            if (genre == null)
                throw new ArgumentNullException();
            Genre genreToAdd = await _genreRepository.GetAsync(genre.GenreId);
            if (genreToAdd != null)
                throw new ArgumentException();

            genreToAdd = new Genre(genre.GenreId, genre.Name);
            await _genreRepository.AddAsync(genreToAdd);
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenresAsync()
        {
            IEnumerable<Genre> genres = await _genreRepository.GetAllAsync();
            List<GenreDTO> genresDTO = new List<GenreDTO>();
            foreach (var genre in genres)
            {
                genresDTO.Add(new GenreDTO
                {
                    GenreId = genre.GenreId,
                    Name = genre.Name,
                    Albums = genre.Albums.Select(s => new AlbumDTO
                    {
                        AlbumId = s.AlbumId,
                        Title = s.Title,
                        Price = s.Price
                    }).ToList()
                });
            }
            return genresDTO;
        }

        public async Task<GenreDTO> GetGenreAsync(Guid id)
        {
            Genre genre = await _genreRepository.GetAsync(id);
            if (genre == null)
                return null;
            return new GenreDTO {
                GenreId = genre.GenreId,
                Name = genre.Name,
                Albums = genre.Albums.Select(s => new AlbumDTO
                {
                    AlbumId = s.AlbumId,
                    Title = s.Title,
                    Price = s.Price,
                    AlbumGenre = new GenreDTO
                    {
                        GenreId = s.Genre.GenreId,
                        Name = s.Genre.Name
                    }
                }).ToList()
            };
        }

        public async Task RemoveGenreAsync(Guid id)
        {
            await _genreRepository.DeleteAsync(id);
        }

        public async Task UpdateGenreAsync(GenreDTO genre)
        {
            if (genre == null)
                throw new ArgumentNullException();

            Genre genreToUpdate = await _genreRepository.GetAsync(genre.GenreId);
            if (genreToUpdate == null)
                throw new ArgumentNullException();

            genreToUpdate = new Genre(genre.GenreId, genre.Name);
            await _genreRepository.UpdateAsync(genreToUpdate);
        }
    }
}
