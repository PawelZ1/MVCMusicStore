using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Models
{
    public class Artist
    {
        [Key]
        public Guid ArtistId { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Country { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public virtual ICollection<Album> Albums { get; set; }

        public Artist(Guid artistId, string name, string country)
        {
            ArtistId = artistId;
            Name = name;
            Country = country;
            Update();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();
            Name = name;
            Update();
        }

        public void SetCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException();
            Country = country;
            Update();
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
