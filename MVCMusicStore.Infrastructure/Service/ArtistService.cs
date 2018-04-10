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
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<ArtistDTO> GetArtistAsync(Guid id)
        {
            Artist artist = await _artistRepository.GetAsync(id);
            if (artist == null)
                return null;

            return new ArtistDTO
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                Country = artist.Country
            };
        }

        public async Task CreateArtistAsync(ArtistDTO artist)
        {
            if (artist == null)
                throw new ArgumentNullException();

            Artist artistToAdd = await _artistRepository.GetAsync(artist.ArtistId);
            if (artistToAdd != null)
                throw new ArgumentException();

            artistToAdd = new Artist(artist.ArtistId, artist.Name, artist.Country);
            await _artistRepository.AddAsync(artistToAdd);
        }

        public async Task<IEnumerable<ArtistDTO>> GetAllArtistsAsync()
        {
            IEnumerable<Artist> artists = await _artistRepository.GetAllAsync();
            List<ArtistDTO> artistsDTO = new List<ArtistDTO>();
            foreach (var artist in artists)
            {
                artistsDTO.Add(new ArtistDTO
                {
                    ArtistId = artist.ArtistId,
                    Name = artist.Name,
                    Country = artist.Country
                });
            }
            return artistsDTO;
        }

        public async Task RemoveArtistAsync(Guid id)
        {
            Artist artistToRemove = await _artistRepository.GetAsync(id);
            if (artistToRemove == null)
                throw new ArgumentNullException();

            await _artistRepository.DeleteAsync(id);
        }

        public async Task UpdateArtistAsync(ArtistDTO artist)
        {
            if (artist == null)
                throw new ArgumentNullException();
            Artist artistToUpdate = await _artistRepository.GetAsync(artist.ArtistId);

            if (artistToUpdate == null)
                throw new ArgumentNullException();

            artistToUpdate = new Artist(artist.ArtistId, artist.Name, artist.Country);
            await _artistRepository.UpdateAsync(artistToUpdate);
        }
    }
}
